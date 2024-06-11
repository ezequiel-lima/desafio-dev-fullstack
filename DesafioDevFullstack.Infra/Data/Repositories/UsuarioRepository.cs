using DesafioDevFullstack.Domain.Entities;
using DesafioDevFullstack.Infra.Data.Repositories.Interfaces;

namespace DesafioDevFullstack.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DesafioDataContext context) : base(context)
        {
        }

        public Task<Usuario> GetByNameAndPasswordAsync(string nome, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
