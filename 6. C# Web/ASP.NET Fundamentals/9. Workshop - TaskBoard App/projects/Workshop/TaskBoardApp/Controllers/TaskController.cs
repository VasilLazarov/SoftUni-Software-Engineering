using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;
using System.Security.Claims;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext context;

        public TaskController(TaskBoardAppDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var taskModel = new TaskFormModel()
            {
                Boards = await GetBoards()
            };
            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!(await GetBoards()).Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Boards = await GetBoards();

                return View(model);
            }

            string currentUserId = GetUserId();

            var newTask = new Task()
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                BoardId = model.BoardId,
                OwnerId = currentUserId,
            };
            await context.Tasks.AddAsync(newTask);
            await context.SaveChangesAsync();

            //var boards = context.Boards;

            return RedirectToAction("Index", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await context.Tasks
                .Where(b => b.Id == id)
                .Select(b => new TaskDetailsViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    CreatedOn = b.CreatedOn != null /*&& b.CreatedOn.Value*/ 
                        ? b.CreatedOn.Value.ToString("dd/MM/yyyy HH:mm") 
                        : "",
                    Board = b.Board != null ? b.Board.Name : "",
                    Owner = b.Owner.UserName
                })
                .FirstOrDefaultAsync();

            if(task == null)
            {
                return BadRequest();
            }
            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await context.Tasks.FindAsync(id);

            if(task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if(currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var taskModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = await GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            var task = await context.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!(await GetBoards()).Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            if (!ModelState.IsValid)
            {
                taskModel.Boards = await GetBoards();

                return View(taskModel);
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await context.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
            var task = await context.Tasks.FindAsync(taskModel.Id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Board");
        }


        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<IEnumerable<TaskBoardModel>> GetBoards()
        {
            var boards = await context.Boards
                .Select(b => new TaskBoardModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                })
                .ToListAsync();

            return boards;
        }

        
    }
}
