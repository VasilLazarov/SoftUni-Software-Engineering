using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext context;

        public SeminarController(SeminarHubDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var seminars = await context.Seminars
                .AsNoTracking()
                .Select(s => new SeminarViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    Category = s.Category.Name,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.SeminarDateFormat, CultureInfo.InvariantCulture),
                    Organizer = s.Organizer.UserName
                })
                .ToListAsync();

            return View(seminars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarFormModel();
            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormModel model)
        {
            DateTime dateAndTime = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.DateAndTime,
                DataConstants.SeminarDateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState.AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.SeminarDateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            var newSeminar = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                DateAndTime = dateAndTime,
                Duration = model.Duration,
                CategoryId = model.CategoryId,
                OrganizerId = GetUserId()
            };

            await context.Seminars.AddAsync(newSeminar);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var seminarForEdit = await context.Seminars
                .FindAsync(id);

            if (seminarForEdit == null)
            {
                return BadRequest();
            }

            if (seminarForEdit.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new SeminarFormModel()
            {
                Topic = seminarForEdit.Topic,
                Lecturer = seminarForEdit.Lecturer,
                Details = seminarForEdit.Details,
                DateAndTime = seminarForEdit.DateAndTime.ToString(DataConstants.SeminarDateFormat, CultureInfo.InvariantCulture),
                Duration = seminarForEdit.Duration,
                CategoryId = seminarForEdit.CategoryId
            };
            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SeminarFormModel model)
        {
            var seminarForEdit = await context.Seminars
                .FindAsync(id);

            if (seminarForEdit == null)
            {
                return BadRequest();
            }

            if (seminarForEdit.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime dateAndTime = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.DateAndTime,
                DataConstants.SeminarDateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState.AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.SeminarDateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            seminarForEdit.Topic = model.Topic;
            seminarForEdit.Lecturer = model.Lecturer;
            seminarForEdit.Details = model.Details;
            seminarForEdit.DateAndTime = dateAndTime;
            seminarForEdit.Duration = model.Duration;
            seminarForEdit.CategoryId = model.CategoryId;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Seminars
                .Where(s => s.Id == id)
                .AsNoTracking()
                .Select(s => new SeminarDetailsModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    Details = s.Details,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.SeminarDateFormat, CultureInfo.InvariantCulture),
                    Duration = s.Duration,
                    Category = s.Category.Name,
                    Organizer = s.Organizer.UserName
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var seminar = await context.Seminars
            .FindAsync(id);

            if (seminar == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != seminar.OrganizerId)
            {
                return Unauthorized();
            }

            var model = new SeminarDeleteModel()
            {
                Id = seminar.Id,
                Topic = seminar.Topic,
                DateAndTime = seminar.DateAndTime.ToString(DataConstants.SeminarDateFormat, CultureInfo.InvariantCulture)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var seminar = await context.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (seminar.SeminarsParticipants.Any(sp => sp.SeminarId == seminar.Id && sp.ParticipantId == currentUserId))
            {
                return RedirectToAction(nameof(All));
            }
            seminar.SeminarsParticipants.Add(new SeminarParticipant()
            {
                SeminarId = seminar.Id,
                ParticipantId = currentUserId
            });

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string currentUserId = GetUserId();

            var seminars = await context.SeminarsParticipant
                .Where(sp => sp.ParticipantId == currentUserId)
                .Include(sp => sp.Seminar)
                .AsNoTracking()
                .Select(sp => new SeminarJoinedModel()
                {
                    Id = sp.SeminarId,
                    Topic = sp.Seminar.Topic,
                    Lecturer = sp.Seminar.Lecturer,
                    DateAndTime = sp.Seminar.DateAndTime.ToString(DataConstants.SeminarDateFormat, CultureInfo.InvariantCulture)
                })
                .ToListAsync();

            return View(seminars);
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var seminar = await context.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if(seminar == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            var seminarParticipant = seminar.SeminarsParticipants
                .FirstOrDefault(sp => sp.ParticipantId == currentUserId);

            if(seminarParticipant == null)
            {
                return BadRequest();
            }

            seminar.SeminarsParticipants.Remove(seminarParticipant);

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SeminarDeleteModel model)
        {
            var seminar = await context.Seminars
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync(s => s.Id == model.Id);

            if (seminar == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != seminar.OrganizerId)
            {
                return Unauthorized();
            }
            var seminarParticipantsAll = seminar.SeminarsParticipants.ToList();
            foreach (var item in seminarParticipantsAll)
            {
                seminar.SeminarsParticipants.Remove(item);
            }
            context.Seminars.Remove(seminar);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }


        private string GetUserId()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            return userId;
        }

        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            var categories = await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return categories;
        }
    }
}
