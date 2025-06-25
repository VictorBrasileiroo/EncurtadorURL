using EncurtadorUrl.Aplication.Dto;
using EncurtadorUrl.Aplication.Interfaces;
using EncurtadorUrl.Aplication.Services;
using EncurtadorURL.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EncurtadorURL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _service;

        public UrlController(IUrlService service)
        {
            _service = service;
        }

        [HttpPost("encurtar")]
        public async Task<ActionResult> Encurtar([FromBody] UrlDto dto)
        {
            try
            {
                var response = await _service.EncurtarUrl(dto);
                var urlEncurtada = $"{Request.Scheme}://{Request.Host}/{response.UrlCurta}";

                return Ok(new UrlResponseDto
                {
                    UrlOriginal = response.UrlLonga,
                    UrlEncurtada = urlEncurtada,
                    CodigoCurto = response.UrlCurta
                });
            }
            catch (Exception ex)
            {
                {
                    return StatusCode(500, new { Mensagem = "Erro interno.", Detalhes = ex.Message });
                }
            }
        }
    }
}
