using Blogging.DTO;
using Blogging.Interfaces;
using Blogging.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogging.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly BloggingContext _context;

        public AuthorRepository(BloggingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task AddAsync(Author entity)
        {
            await _context.Authors.AddAsync(entity);
        }

        public void Update(Author entity)
        {
            _context.Authors.Update(entity);
        }

        public void Delete(Author entity)
        {
            _context.Authors.Remove(entity);
        }
    }

}
