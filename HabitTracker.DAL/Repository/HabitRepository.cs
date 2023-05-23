using HabitTracker.DAL.Data;
using HabitTracker.DAL.Repository.IRepository;
using HabitTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.DAL.Repository
{
    public class HabitRepository : BaseRepository<Habit>, IHabitRepository
    {
        public HabitRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Habit>> GetListHabitByUserIdAsync(string id)
        {
            return await dbSet.Where(i => i.ApplicationUserId == id).ToListAsync();
        }
    }
}
