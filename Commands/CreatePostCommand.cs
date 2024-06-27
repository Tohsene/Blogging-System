using Blogging.Interfaces;
using Blogging.Models;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Blogging.Commands
{
    public class CreatePostCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }
        public int BlogId { get; set; }
    }

    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                DatePublished = request.DatePublished,
                BlogId = request.BlogId
            };

            await _unitOfWork.Posts.AddAsync(post);
            await _unitOfWork.SaveChangesAsync();

            return post.Id;
        }
    }

}
