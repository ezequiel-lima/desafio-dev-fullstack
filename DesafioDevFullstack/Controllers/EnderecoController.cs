using DesafioDevFullstack.Application.Services.External.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDevFullstack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoExternoService _enderecoExternoService;

        public EnderecoController(IEnderecoExternoService enderecoExternoService)
        {
            _enderecoExternoService = enderecoExternoService;
        }

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
