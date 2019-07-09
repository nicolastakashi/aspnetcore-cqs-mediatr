using CQS.Api.Commands;
using CQS.Api.Domain.Notification;
using CQS.Api.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CQS.Api.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IMediator _bus;
        private readonly IDomainNotificationContext _notificationContext;

        public UserController(IMediator bus, IDomainNotificationContext notificationContext)
        {
            _bus = bus;
            _notificationContext = notificationContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserCommand command)
        {
            await _bus.Send(command);

            if (_notificationContext.HasErrorNotifications)
            {
                var notifications = _notificationContext.GetErrorNotifications();
                var message = string.Join(", ", notifications.Select(x => x.Value));
                return BadRequest(message);
            }

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
