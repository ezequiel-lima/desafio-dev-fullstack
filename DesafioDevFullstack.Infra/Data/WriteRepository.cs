using DesafioDevFullstack.Infra.Data.Interfaces;

namespace DesafioDevFullstack.Infra.Data
{
    public sealed class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        protected readonly DesafioDataContext _context;

        public WriteRepository(DesafioDataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
