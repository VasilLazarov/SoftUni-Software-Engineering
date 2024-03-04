using ForumApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Core.Contracts
{
    public interface IPostService
    {
        Task AddPostAsync(PostModel model);
        Task DeletePostAsync(int id);
        Task EditPostAsync(PostModel model);
        Task<IEnumerable<PostModel>> GetAllPostsAsync();
        Task<PostModel?> GetPostById(int id);
    }
}
