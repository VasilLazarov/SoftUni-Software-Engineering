using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ForumDbContext context;

        private readonly ILogger<PostService> logger;

        public PostService(
            ForumDbContext _context,
            ILogger<PostService> _logger)
        {
            context = _context;
            logger = _logger;
        }

        public async Task AddPostAsync(PostModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content,
            };

            try
            {
                await context.Posts.AddAsync(post);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "PostService.AddAsync");
                throw new ApplicationException("Operation failed. Please, try again!");
            }

            
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await context.Posts
                .FindAsync(id);

            if (post == null)
            {
                throw new ApplicationException("Invalid post id!");
            }

            context.Posts.Remove(post);
            await context.SaveChangesAsync();
        }

        public async Task EditPostAsync(PostModel model)
        {
            var post = await context.Posts.FindAsync(model.Id);

            if (post == null)
            {
                //logger.LogError("PostService.GetPostById - invalid id!");
                throw new ApplicationException("Invalid post id!");
            }

            post.Title = model.Title;
            post.Content = model.Content;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostModel>> GetAllPostsAsync()
        {
            var posts = await context.Posts
                .Select(p => new PostModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .AsNoTracking()
                .ToListAsync();

            return posts;
        }

        public async Task<PostModel?> GetPostById(int id)
        {
            var post = await context.Posts
                .AsNoTracking()
                .Select(p => new PostModel()
                {
                    Id = p.Id,
                    Content = p.Content,
                    Title = p.Title,
                })
                .FirstOrDefaultAsync(p => p.Id == id);

            //if(post == null)
            //{
            //    //logger.LogError("PostService.GetPostById - invalid id!");
            //    throw new ApplicationException("Invalid post id!");
            //}

            return post;
        }
    }
}
