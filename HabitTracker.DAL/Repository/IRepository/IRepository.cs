namespace HabitTracker.DAL.Repository.IRepository
{
    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
