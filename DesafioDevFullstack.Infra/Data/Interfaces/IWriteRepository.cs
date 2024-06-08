﻿namespace DesafioDevFullstack.Infra.Data.Interfaces
{
    public interface IWriteRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
