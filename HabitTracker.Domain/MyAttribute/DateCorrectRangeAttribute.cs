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
            var model = validationContext.ObjectInstance as Habit;

            if (model != null)
            {
                bool isDateValid = model.StartDate <= model.FinishDate;

                if (isDateValid)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(string.Empty);
                }
            }

            return ValidationResult.Success;
        }
    }
}
