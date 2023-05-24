using HabitTracker.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace HabitTracker.Domain.MyAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateCorrectRangeAttribute : ValidationAttribute
    {
        public bool ValidateStartDate { get; set; }
        public bool ValidateEndDate { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext?.ObjectInstance is Habit model &&
                model.StartDate > model.FinishDate)
                return new ValidationResult(string.Empty);

            return ValidationResult.Success;
        }
    }
}
