using HabitTracker.DAL.Data;
using HabitTracker.DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.DAL.Repository
{
    public class BaseRepository<T> : IRepository<T> 
        where T : class
    {
        protected ApplicationDbContext _db { get; set; }
        protected DbSet<T> dbSet;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task CreateAsync(T item)
        {
            dbSet.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            dbSet.Remove(dbSet.Find(id));
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            dbSet.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
