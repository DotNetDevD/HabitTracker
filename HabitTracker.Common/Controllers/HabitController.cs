using HabitTracker.DAL.Repository.IRepository;
using HabitTracker.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.Common.Controllers
{
    public class HabitController : Controller
    {
        private readonly IHabitRepository _habitRepository;

        public HabitController(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }

        public async Task<IActionResult> Index()
        {
            var habitsList = await _habitRepository.GetListAsync();
            ResetCount(habitsList);
            return View(habitsList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Habit habit)
        {
            if (ModelState.IsValid)
            {
                habit.NextReset = DateTime.Now.AddDays(7 - (int)DateTime.Now.DayOfWeek);
                await _habitRepository.CreateAsync(habit);
                return RedirectToAction("Index");
            }

            return View(habit);
        }

        //GET - TRACK
        public async Task<IActionResult> Track(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return NotFound();
            }

            Habit habit = await _habitRepository.GetByIdAsync(id.GetValueOrDefault());

            if (habit == null)
            {
                return NotFound();
            }

            IncrementCurrentCount(habit);
            CheckGoalMet(habit);

            await _habitRepository.UpdateAsync(habit);

            return RedirectToAction("Index");
        }

        private void IncrementCurrentCount(Habit habit)
        {
            habit.CurrentCount++;
        }

        private void CheckGoalMet(Habit habit)
        {
            if (habit.CurrentCount >= habit.WeeklyGoal)
            {
                habit.IsGoalMet = true;
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return NotFound();
            }

            Habit habit = await _habitRepository.GetByIdAsync(id.Value);

            if (habit == null)
            {
                return NotFound();
            }

            return View(habit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Habit habit)
        {
            if (ModelState.IsValid)
            {
                await _habitRepository.UpdateAsync(habit);
                return RedirectToAction("Index");
            }
            return View(habit);
        }

        //GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return NotFound();
            }

            Habit habit = await _habitRepository.GetByIdAsync(id.Value);

            if (habit == null)
            {
                return NotFound();
            }

            return View(habit);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return NotFound();
            }

            Habit habitToDelete = await _habitRepository.GetByIdAsync(id.Value);

            if (habitToDelete == null)
            {
                return NotFound();
            }

            await _habitRepository.DeleteAsync(habitToDelete.Id);

            return RedirectToAction("Index");
        }

        public async void ResetCount(IEnumerable<Habit> habitsList)
        {
            var date = DateTime.Today.Date;
            foreach (Habit habit in habitsList)
            {
                if (DateTime.Compare(date, habit.NextReset) >= 0)
                {
                    habit.NextReset = DateTime.Now.AddDays(7 - (int)date.DayOfWeek);
                    habit.CurrentCount = 0;
                    await _habitRepository.UpdateAsync(habit);
                }
            }
        }
    }
}
