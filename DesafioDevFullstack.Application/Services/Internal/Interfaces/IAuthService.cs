using DesafioDevFullstack.Application.Dtos.Contas;
using DesafioDevFullstack.Domain.Entities;

namespace DesafioDevFullstack.Application.Services.Internal.Interfaces
{
    public interface IAuthService
    {
        Task<(bool Success, string Token, Usuario Usuario)> LoginAsync(LoginDto model);
        Task<(bool Success, Usuario Usuario)> CreateAccountAsync(CriarContaDto model);
    }
}
