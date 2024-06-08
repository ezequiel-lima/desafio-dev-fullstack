using DesafioDevFullstack.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioDevFullstack.Infra.Data
{
    public sealed class ReadRepository<T> : IReadRepository<T> where T : class
    {
        protected readonly DesafioDataContext _context;

        public ReadRepository(DesafioDataContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
