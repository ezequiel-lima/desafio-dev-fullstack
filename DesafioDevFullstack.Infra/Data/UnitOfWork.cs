using DesafioDevFullstack.Infra.Data.Interfaces;

namespace DesafioDevFullstack.Infra.Data
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DesafioDataContext _context;
        private readonly Dictionary<Type, object> _readRepositories = new();
        private readonly Dictionary<Type, object> _writeRepositories = new();

        public UnitOfWork(DesafioDataContext context)
        {
            _context = context;
        }

        public IReadRepository<T> ReadRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!_readRepositories.ContainsKey(type))
            {
                var repositoryInstance = new ReadRepository<T>(_context);
                _readRepositories[type] = repositoryInstance;
            }
            return (IReadRepository<T>)_readRepositories[type];
        }

        public IWriteRepository<T> WriteRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!_writeRepositories.ContainsKey(type))
            {
                var repositoryInstance = new WriteRepository<T>(_context);
                _writeRepositories[type] = repositoryInstance;
            }
            return (IWriteRepository<T>)_writeRepositories[type];
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
