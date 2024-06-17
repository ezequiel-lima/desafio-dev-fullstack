using DesafioDevFullstack.Application.Dtos.Contas;
using DesafioDevFullstack.Application.Services.Internal.Interfaces;
using DesafioDevFullstack.Domain.Entities;
using DesafioDevFullstack.Infra.Data.Repositories.Interfaces;
using SecureIdentity.Password;

namespace DesafioDevFullstack.Application.Services.Internal
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<(bool Success, string Token, Usuario Usuario)> LoginAsync(LoginDto model)
        {
            var usuario = await _usuarioRepository.GetByNameAsync(model.Nome);

            if (usuario is null)
                return (false, null, null);

            if (!PasswordHasher.Verify(usuario.Senha, model.Senha))
                return (false, null, null);

            var token = TokenService.GenerateToken(usuario);
            usuario.LimparSenha();
            return (true, token, usuario);
        }

        public async Task<(bool Success, Usuario Usuario)> CreateAccountAsync(CriarContaDto model)
        {
            var usuarioExistente = await _usuarioRepository.GetByNameAsync(model.Nome);

            if (usuarioExistente != null)
                return (false, null);

            var senha = PasswordHasher.Hash(model.Senha);

            var novoUsuairo = new Usuario(model.Nome, senha, model.Role);

            return (true, novoUsuairo);
        }
    }
}
