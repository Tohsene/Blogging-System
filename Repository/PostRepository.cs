using Blogging.DTO;
using Blogging.Interfaces;
using Blogging.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogging.Repository
{
    public class PostRepository : IRepository<Post>
    {
        private readonly BloggingContext _context;

        public PostRepository(BloggingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task AddAsync(Post entity)
        {
            await _context.Posts.AddAsync(entity);
        }

        public void Update(Post entity)
        {
            _context.Posts.Update(entity);
        }

        public void Delete(Post entity)
        {
            _context.Posts.Remove(entity);
        }
    }

}
