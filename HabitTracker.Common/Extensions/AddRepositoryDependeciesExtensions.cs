using HabitTracker.DAL.Repository;
using HabitTracker.DAL.Repository.IRepository;

namespace HabitTracker.Common.Extensions
{
    public static class AddRepositoryDependeciesExtensions
    {
        public static void AddRepositoryDependecies(this IServiceCollection services)
        {
            services.AddScoped<IHabitRepository, HabitRepository>();
        }
    }
}
