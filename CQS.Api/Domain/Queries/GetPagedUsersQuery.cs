using System.Collections.Generic;
using CQS.Api.Domain.Queries.Results;
using MediatR;

namespace CQS.Api.Domain.Queries
{
    public class GetPagedUsersQuery : IRequest<IEnumerable<GetPagedUsersQueryResult>>
    {
        public GetPagedUsersQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; protected set; }
        public int PageSize { get; protected set; }

        public static GetPagedUsersQuery Create(int page, int pageSize)
            => new GetPagedUsersQuery(page, pageSize);
        
    }
}
