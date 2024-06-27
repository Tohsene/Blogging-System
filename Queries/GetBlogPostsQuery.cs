using Blogging.Interfaces;
using Blogging.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Blogging.Queries
{
    public class GetBlogPostsQuery : IRequest<IEnumerable<Post>>
    {
        public int BlogId { get; set; }
    }

    public class GetBlogPostsQueryHandler : IRequestHandler<GetBlogPostsQuery, IEnumerable<Post>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBlogPostsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> Handle(GetBlogPostsQuery request, CancellationToken cancellationToken)
        {
            var blog = await _unitOfWork.Blogs.GetByIdAsync(request.BlogId);
            return blog?.Posts ?? new List<Post>();
        }
    }

}
