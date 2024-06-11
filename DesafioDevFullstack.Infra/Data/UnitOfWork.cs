using DesafioDevFullstack.Infra.Data.Interfaces;

namespace DesafioDevFullstack.Infra.Data
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DesafioDataContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(DesafioDataContext context)
        {
            _context = context;
        }

        public IBaseRepository<T> BaseRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = new BaseRepository<T>(_context);
                _repositories[type] = repositoryInstance;
            }
            return (IBaseRepository<T>)_repositories[type];
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
