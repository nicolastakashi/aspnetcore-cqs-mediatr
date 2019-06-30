using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Api.Domain.Queries;
using CQS.Api.Domain.Queries.Results;
using CQS.Api.Infra.Data;
using MediatR;

namespace CQS.Api.Domain.QueryHandlers
{
    public class UserQueryHandler : IRequestHandler<GetPagedUsersQuery, IEnumerable<GetPagedUsersQueryResult>>
    {
        private readonly IUserRepository _userRepository;

        public UserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<GetPagedUsersQueryResult>> Handle(GetPagedUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAsync(request.Page, request.PageSize);

            return users.Select(x => new GetPagedUsersQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Birthday = x.Birthday
            });
        }
    }
}
