using HabitTracker.Domain.Enum;
using HabitTracker.Domain.MyAttribute;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HabitTracker.Domain.Entity
{
    public class Habit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Type of Habit")]
        public HabitType HabitType { get; set; } = HabitType.Personal;

        [StringLength(255, ErrorMessage = "Maximum length is 255")]
        public string? Description { get; set; }

        [DisplayName("Weekly Goal")]
        [Required]
        [Range(1, 7)]
        public int WeeklyGoal { get; set; }

        [DisplayName("Current Count")]
        public int CurrentCount { get; set; }

        public bool IsGoalMet { get; set; }

        public DateTime NextReset { get; set; }
        [DisplayName("Start Date")]
        [DateCorrectRange(ValidateStartDate = true, ErrorMessage = "Start date shouldn't be older than the current date")]
        public DateTime StartDate { get; set; }

        [DisplayName("Finish Date")]
        [DateCorrectRange(ValidateEndDate = true, ErrorMessage = "End date can't be younger than start date")]
        public DateTime FinishDate { get; set; }

        public string? ApplicationUserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }

    }
}
