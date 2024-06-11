using DesafioDevFullstack.Domain.Entities;
using DesafioDevFullstack.Infra.Data.Interfaces;

namespace DesafioDevFullstack.Infra.Data.Repositories.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> GetByNameAndPasswordAsync(string nome, string senha);
    }
}
