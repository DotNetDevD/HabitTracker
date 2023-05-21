using HabitTracker.DAL.Data;
using HabitTracker.DAL.Repository.IRepository;
using HabitTracker.Domain.Entity;

namespace HabitTracker.DAL.Repository
{
    public class HabitRepository : BaseRepository<Habit>, IHabitRepository
    {
        public HabitRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
