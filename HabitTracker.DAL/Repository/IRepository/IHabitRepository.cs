using HabitTracker.Domain.Entity;

namespace HabitTracker.DAL.Repository.IRepository
{
    public interface IHabitRepository : IRepository<Habit>
    {
        Task<IEnumerable<Habit>> GetListHabitByUserIdAsync(string id);
    }
}
