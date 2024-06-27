using Blogging.Interfaces;
using Blogging.Models;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Blogging.Commands
{
    public class RegisterAuthorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class RegisterAuthorCommandHandler : IRequestHandler<RegisterAuthorCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(RegisterAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.Name,
                Email = request.Email
            };

            await _unitOfWork.Authors.AddAsync(author);
            await _unitOfWork.SaveChangesAsync();

            return author.Id;
        }
    }

}
