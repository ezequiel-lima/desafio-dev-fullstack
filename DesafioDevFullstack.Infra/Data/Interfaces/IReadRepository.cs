namespace DesafioDevFullstack.Infra.Data.Interfaces
{
    public interface IReadRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
