namespace DesafioDevFullstack.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<T> BaseRepository<T>() where T : class;
        Task<int> CompleteAsync();
    }
}
