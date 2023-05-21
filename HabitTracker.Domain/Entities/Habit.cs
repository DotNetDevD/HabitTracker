using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HabitTracker.Domain.Entity
{
    public class Habit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Weekly Goal")]
        [Required]
        [Range(1, 7)]
        public int WeeklyGoal { get; set; }

        [DisplayName("Current Count")]
        public int CurrentCount { get; set; }

        public bool IsGoalMet { get; set; }

        public DateTime NextReset { get; set; }

    }
}
