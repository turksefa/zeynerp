namespace zeynerp.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IReadOnlyList<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}