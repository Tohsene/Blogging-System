using Blogging.Models;
using System.Threading.Tasks;
using System;

namespace Blogging.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Blog> Blogs { get; }
        IRepository<Post> Posts { get; }
        IRepository<Author> Authors { get; }
        Task<int> SaveChangesAsync();
    }
}
