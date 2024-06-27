using Blogging.DTO;
using Blogging.Interfaces;
using Blogging.Models;
using Blogging.Repository;
using System.Threading.Tasks;

namespace Blogging.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BloggingContext _context;
        private IRepository<Blog> _blogRepository;
        private IRepository<Post> _postRepository;
        private IRepository<Author> _authorRepository;

        public UnitOfWork(BloggingContext context)
        {
            _context = context;
        }

        public IRepository<Blog> Blogs => _blogRepository ??= new BlogRepository(_context);
        public IRepository<Post> Posts => _postRepository ??= new PostRepository(_context);
        public IRepository<Author> Authors => _authorRepository ??= new AuthorRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
