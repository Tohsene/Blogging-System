using Blogging.Interfaces;
using Blogging.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogging.Services
{
    public class BloggingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BloggingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewBlogAsync(Blog newBlog)
        {
            await _unitOfWork.Blogs.AddAsync(newBlog);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddNewPostToBlogAsync(Post newPost)
        {
            await _unitOfWork.Posts.AddAsync(newPost);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RegisterNewAuthorAsync(Author newAuthor)
        {
            await _unitOfWork.Authors.AddAsync(newAuthor);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> ListAllPostsByBlogAsync(int blogId)
        {
            var blog = await _unitOfWork.Blogs.GetByIdAsync(blogId);
            if (blog == null) return null;
            return blog.Posts;
        }

        public async Task<IEnumerable<Blog>> ListAllBlogsByAuthorAsync(int authorId)
        {
            var posts = await _unitOfWork.Posts.GetAllAsync();
            return posts.Where(p => p.Blog.Id == authorId).Select(p => p.Blog).Distinct();
        }
    }

}
