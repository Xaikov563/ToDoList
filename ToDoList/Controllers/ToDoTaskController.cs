using System.Collections;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoTaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToDoTaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        //ToDoTask/Index
        public IActionResult Index()
        {
            var List = _context.Tasks.ToList();
            return View(List);
        }

        //ToDoTask/CreatePage

        [HttpGet]
        public IActionResult CreatePage()
        {
            return View();
        }


        //ToDoTask/CreateForm
        [HttpPost]
        public async Task<IActionResult> CreateForm(ToDoTask task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View();
        }

        //ToDoTask/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        //ToDoTask/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        //ToDoTask/Edit/Id/EditFunction
        [HttpPost]
        public async Task<IActionResult> EditFunction(int? id, ToDoTask task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Tasks.Any(e => e.Id == task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Details", new {id = task.Id});
            }
            return View();
        }

        //ToDoTask/DeleteFunction
        [HttpPost]
        public async Task<IActionResult> DeleteFunction(int? id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if(task == null)
            {
                return NotFound();
            }

            _context.Remove(task);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        //ToDoTask/TaskComplete/Id/
        public async Task<IActionResult> TaskComplete(int? id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            task.is_Completed = true;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
    }
}
