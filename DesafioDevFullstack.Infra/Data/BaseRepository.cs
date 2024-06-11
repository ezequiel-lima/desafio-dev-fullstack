using DesafioDevFullstack.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioDevFullstack.Infra.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DesafioDataContext _context;

        public BaseRepository(DesafioDataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
