using System.ComponentModel.DataAnnotations;

namespace HabitTracker.Domain.Enum
{
    public enum HabitType
    {
        [Display(Name = "Personal")]
        Personal = 1,
        [Display(Name = "Drink Water")]
        DrinkWater,
        [Display(Name = "Running")]
        Running,
        [Display(Name = "Reading")]
        Reading,
        [Display(Name = "Learning")]
        Learning,
        [Display(Name = "Walking")]
        Walking,
        [Display(Name = "Meditation")]
        Meditation,
        [Display(Name = "Cross Fit")]
        CrossFit
    }
}
