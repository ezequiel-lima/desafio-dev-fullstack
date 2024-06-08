using Asp.Versioning;
using DesafioDevFullstack.Application.Services.Internal.Interfaces;
using DesafioDevFullstack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDevFullstack.API.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class EnderecoController : ControllerBase
    {
        private readonly IGenericService<Endereco> _enderecoService;

        public EnderecoController(IGenericService<Endereco> enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public async Task<IActionResult> PostEnderecoAsync(Endereco endereco)
        {
            var validationResult = endereco.Validate();

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _enderecoService.AddAsync(endereco);
            return Ok(endereco);
        }
    }
}
