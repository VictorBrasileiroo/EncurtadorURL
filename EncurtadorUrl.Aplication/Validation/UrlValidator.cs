using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncurtadorUrl.Aplication.Dto;
using FluentValidation;

namespace EncurtadorUrl.Aplication.Validation
{
    public class UrlValidator : AbstractValidator<UrlDto>
    {
        public UrlValidator()
        {
            RuleFor(url => url.UrlLonga)
                .NotEmpty()
                .WithMessage("A URL original não pode ser vazia.");

            RuleFor(url => url.UrlLonga)
                .Must(BeAValidUrl)
                .WithMessage("Formato de URL inválido.");

            RuleFor(url => url.UrlLonga)
                .MaximumLength(2048)
                .WithMessage("A URL original é muito longa (máximo 2048 caracteres).");
        }

        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri result) &&
                   (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }
    }
}
