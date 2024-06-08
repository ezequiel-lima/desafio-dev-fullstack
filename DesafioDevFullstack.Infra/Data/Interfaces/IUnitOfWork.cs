namespace DesafioDevFullstack.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IReadRepository<T> ReadRepository<T>() where T : class;
        IWriteRepository<T> WriteRepository<T>() where T : class;
        Task<int> CompleteAsync();
    }
}
