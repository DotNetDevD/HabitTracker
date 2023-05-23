﻿using Microsoft.AspNetCore.Identity;

namespace HabitTracker.Domain.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Habit> Habits { get; set; }
    }
}
