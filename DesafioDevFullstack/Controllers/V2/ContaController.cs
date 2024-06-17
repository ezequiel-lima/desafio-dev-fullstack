using Asp.Versioning;
using DesafioDevFullstack.Application.Dtos.Contas;
using DesafioDevFullstack.Application.Services.Internal.Interfaces;
using DesafioDevFullstack.Infra.Data.Interfaces;
using DesafioDevFullstack.Infra.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDevFullstack.API.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class ContaController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContaController(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginDto model)
        {
            var result = await _authService.LoginAsync(model);

            if (!result.Success)
                return BadRequest(new { message = "Usuário ou senha inválidos" });

            return Ok(new
            {
                usuario = result.Usuario,
                token = result.Token
            });
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> CreateAccountAsync(CriarContaDto model)
        {
            var result = await _authService.CreateAccountAsync(model);

            if (!result.Success)
                return BadRequest(new { message = "Usuário inválido" });

            await _usuarioRepository.AddAsync(result.Usuario);
            await _unitOfWork.CompleteAsync();

            return Ok(result.Usuario);
        }
    }
}
