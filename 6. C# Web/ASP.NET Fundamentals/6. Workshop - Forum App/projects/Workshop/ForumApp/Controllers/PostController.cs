using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(ILogger<PostController> _logger, IPostService _postService)
        {
            postService = _postService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<PostModel> models = await postService.GetAllPostsAsync();

            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new PostModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await postService.AddPostAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            PostModel? model = await postService.GetPostById(id);

            if (model == null)
            {
                ModelState.AddModelError("All", "Invalid post");

                IEnumerable<PostModel> models = await postService.GetAllPostsAsync();


                return View("Index", models);

            }

            // I think this is return is not good because return empty edit form and client can try to write someting and push sumbit button and we get exception
            return View(model);
            #region my tests
            //try
            //{
            //    PostModel model = await postService.GetPostById(id);

            //    return View(model);
            //}
            //catch (Exception)
            //{
            //    ModelState.AddModelError("All", "Operation failed. Please, try again!");
            //}
            //return View();
            ////return RedirectToAction(nameof(Index));
            #endregion
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await postService.EditPostAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await postService.DeletePostAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
