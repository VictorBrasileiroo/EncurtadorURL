using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EncurtadorUrl.Aplication.Dto;
using EncurtadorUrl.Aplication.Interfaces;
using EncurtadorUrl.Aplication.Validation;
using EncurtadorURL.Core.IRepositories;
using EncurtadorURL.Core.Models;
using EncurtadorURL.Core.Shared;
using FluentValidation;

namespace EncurtadorUrl.Aplication.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _repository;

        public UrlService(IUrlRepository repository)
        {
            _repository = repository;
        }

        public async Task<UrlModel> EncurtarUrl(UrlDto dto)
        {

            var validator = new UrlValidator();
            var result = validator.Validate(dto);

            if (!result.IsValid)
            {
                var erros = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(erros);
            }

            var longUrl = dto.UrlLonga;

            var urlJáCadastrada = await _repository.GetShortUrlByCode(longUrl);

            if(urlJáCadastrada != null)
            {
                return urlJáCadastrada;
            }

            var shortCode = GerarCodigoUnico();

            var urlEncurtada = new UrlModel
            {
                UrlLonga = longUrl,
                UrlCurta = shortCode,
                DataCriacao = DateTime.UtcNow
            };

            return await _repository.AddShortUrl(urlEncurtada);

        }

        public async Task<string> RedirecionarUrl(string shortCode)
        {
            //validar se existe
            var url = await _repository.GetLongUrlByCode(shortCode);

            if(url == null)
            {
                throw new Exception("Essa url não foi encurtada");
            }

            return url.UrlLonga;
        }

        private string GerarCodigoUnico()
        {
            const int tamanhoDesejado = 7;
            string codigoGerado = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] dados = new byte[8];
                rng.GetBytes(dados);
                long valorAleatorio = BitConverter.ToInt64(dados, 0);

                valorAleatorio = Math.Abs(valorAleatorio);

                codigoGerado = ConversorBase62.Codificar(valorAleatorio);
            }

            if (codigoGerado.Length > tamanhoDesejado)
            {
                codigoGerado = codigoGerado.Substring(codigoGerado.Length - tamanhoDesejado, tamanhoDesejado);
            }
            else if (codigoGerado.Length < tamanhoDesejado)
            {
                while (codigoGerado.Length < tamanhoDesejado)
                {
                    codigoGerado = ConversorBase62.Alfabeto[0] + codigoGerado;
                }
            }

            return codigoGerado;
        }
    }
}
