using Blogging.Interfaces;
using Blogging.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Blogging.Queries
{
    public class GetBlogsByAuthorQuery : IRequest<IEnumerable<Blog>>
    {
        public int AuthorId { get; set; }
    }

    public class GetBlogsByAuthorQueryHandler : IRequestHandler<GetBlogsByAuthorQuery, IEnumerable<Blog>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBlogsByAuthorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Blog>> Handle(GetBlogsByAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(request.AuthorId);
            return author?.Blogs ?? new List<Blog>();
        }
    }

}
