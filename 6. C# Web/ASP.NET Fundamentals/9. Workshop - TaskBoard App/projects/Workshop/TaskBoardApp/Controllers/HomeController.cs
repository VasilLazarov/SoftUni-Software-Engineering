using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext context;


        public HomeController(TaskBoardAppDbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            //if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Board");
            //}
            var taskBoardsWithCount = await context.Boards
                .Select(b => new HomeBoardModel()
                {
                    BoardName = b.Name,
                    TaskCount = b.Tasks.Count(),
                })
                .ToListAsync();

            var userTaskCount = -1;

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                userTaskCount = context.Tasks
                    .Where(t => t.OwnerId == currentUserId)
                    .Count();
            }

            var modelForView = new HomeViewModel()
            {
                AllTasksCount = await context.Tasks.CountAsync(),
                BoardsWithTasksCount = taskBoardsWithCount,
                UserTasksCount = userTaskCount
            };
            
            return View(modelForView);
        }

    }
}