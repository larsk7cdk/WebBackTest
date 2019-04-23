using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBackTest.web.ApplicationCore.Entities;
using WebBackTest.web.Infrastructure.Data;
using WebBackTest.web.ViewModels.Todo;

namespace WebBackTest.web.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            var entities = await _todoRepository.GetAllAsync();

            if (entities.Count == 0)
                return View("Empty");

            var todos = entities.Select(MapToViewModel);

            return View("Index", todos);
        }

        // DETAILS
        public async Task<IActionResult> Details([Required]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var entity = await _todoRepository.GetByIdAsync(id);

            if (entity == null) return NotFound();

            var todo = MapToViewModel(entity);

            return View(todo);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description,IsDone")] TodoViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new Todo
            {
                CreatedDateTime = DateTime.Now,
                Name = model.Name,
                Description = model.Description,
                IsDone = model.IsDone
            };

            await _todoRepository.CreateAsync(entity);

            return RedirectToAction(nameof(Index));
        }

        // EDIT
        public async Task<IActionResult> Edit([Required]int id)
        {
            var entity = await _todoRepository.GetByIdAsync(id);

            if (entity == null) return NotFound();

            var todo = MapToViewModel(entity);

            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Required]int id, [Bind("Id,Name,Description,IsDone")] TodoViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid) return View(model);

            try
            {
                var entity = await _todoRepository.GetByIdAsync(id);
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.IsDone = model.IsDone;

                await _todoRepository.UpdateAsync(entity);
            }

            catch (DbUpdateConcurrencyException)
            {
                var entity = await _todoRepository.GetByIdAsync(id);
                if (entity == null) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // DELETE
        public async Task<IActionResult> Delete([Required]int id)
        {
            var entity = await _todoRepository.GetByIdAsync(id);

            if (entity == null) return NotFound();

            var todo = MapToViewModel(entity);

            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _todoRepository.GetByIdAsync(id);
            await _todoRepository.DeleteAsync(entity);

            return RedirectToAction(nameof(Index));
        }

        // MAPPER
        private static TodoViewModel MapToViewModel(Todo entity)
        {
            return new TodoViewModel
            {
                Id = entity.Id,
                CreatedDateTime = entity.CreatedDateTime,
                Name = entity.Name,
                Description = entity.Description,
                IsDone = entity.IsDone
            };
        }
    }
}