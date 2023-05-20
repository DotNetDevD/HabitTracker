namespace HabitTracker.Domain.Entity
{
    public class Habit
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public List<string> CompletedDates { get; set; }
        //public bool NotifyEnabled { get; set; }
        //public int? Hours { get; set; }
        //public int? Minutes { get; set; }

    }
}
