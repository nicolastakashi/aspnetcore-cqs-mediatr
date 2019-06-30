using System.Threading.Tasks;
using CQS.Api.Commands;
using CQS.Api.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQS.Api.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IMediator _bus;

        public UserController(IMediator bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserCommand command)
        {
            await _bus.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedAsync([FromQuery]int page = 1, [FromQuery]int pageSize = 10)
        {
            var query = GetPagedUsersQuery.Create(page, pageSize);
            var pagedUsers = await _bus.Send(query);
            return Ok(pagedUsers);
        }
    }
}
