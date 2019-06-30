using System;
using MediatR;

namespace CQS.Api.Commands
{
    public class CreateUserCommand : IRequest
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
