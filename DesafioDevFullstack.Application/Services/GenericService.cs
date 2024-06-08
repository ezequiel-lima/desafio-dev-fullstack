using DesafioDevFullstack.Infra.Data.Interfaces;

namespace DesafioDevFullstack.Application.Services
{
    public class GenericService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReadRepository<T> _readRepository;
        private readonly IWriteRepository<T> _writeRepository;

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readRepository = _unitOfWork.ReadRepository<T>();
            _writeRepository = _unitOfWork.WriteRepository<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _readRepository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _readRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _writeRepository.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _writeRepository.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _readRepository.GetByIdAsync(id);
            if (entity != null)
            {
                _writeRepository.Delete(entity);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
