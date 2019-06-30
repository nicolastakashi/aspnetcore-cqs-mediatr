using System.Threading;
using System.Threading.Tasks;
using CQS.Api.Commands;
using CQS.Api.Entities;
using CQS.Api.Infra.Data;
using MediatR;

namespace CQS.Api.CommandHandlers
{
    public class UserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Create(request);

            await _userRepository.CreateAsync(user);
        }
    }
}
