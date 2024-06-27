using Blogging.Interfaces;
using Blogging.Models;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Blogging.Commands
{
    public class CreateBlogCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBlogCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog
            {
                Name = request.Name,
                Url = request.Url
            };

            await _unitOfWork.Blogs.AddAsync(blog);
            await _unitOfWork.SaveChangesAsync();

            return blog.Id;
        }
    }

}
