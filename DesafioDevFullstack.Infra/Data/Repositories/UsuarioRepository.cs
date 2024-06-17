using DesafioDevFullstack.Domain.Entities;
using DesafioDevFullstack.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioDevFullstack.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DesafioDataContext context) : base(context)
        {
        }

        public async Task<Usuario> GetByNameAsync(string nome)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Nome == nome);
        }
    }
}
