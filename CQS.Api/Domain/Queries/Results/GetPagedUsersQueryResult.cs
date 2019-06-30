using System;

namespace CQS.Api.Domain.Queries.Results
{
    public class GetPagedUsersQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
