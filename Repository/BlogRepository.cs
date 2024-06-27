using Blogging.DTO;
using Blogging.Interfaces;
using Blogging.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogging.Repository
{
    public class BlogRepository : IRepository<Blog>
    {
        private readonly BloggingContext _context;

        public BlogRepository(BloggingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task AddAsync(Blog entity)
        {
            await _context.Blogs.AddAsync(entity);
        }

        public void Update(Blog entity)
        {
            _context.Blogs.Update(entity);
        }

        public void Delete(Blog entity)
        {
            _context.Blogs.Remove(entity);
        }
    }

}
