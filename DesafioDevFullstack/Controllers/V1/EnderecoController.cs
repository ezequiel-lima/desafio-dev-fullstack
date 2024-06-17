using Asp.Versioning;
using DesafioDevFullstack.Application.Services.External.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDevFullstack.API.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoExternoService _enderecoExternoService;

        public EnderecoController(IEnderecoExternoService enderecoExternoService)
        {
            _enderecoExternoService = enderecoExternoService;
        }

        [Authorize]
        [HttpGet("{cep}")]
        public async Task<IActionResult> GetEnderecoByCepAsync(string cep)
        {
            var endereco = await _enderecoExternoService.GetEnderecoByCepAsync(cep);
            if (endereco is null)
            {
                return NotFound();
            }

            return Ok(endereco);
        }
    }
}
