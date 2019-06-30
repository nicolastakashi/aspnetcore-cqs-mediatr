using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQS.Api.Entities;

namespace CQS.Api.Infra.Data
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new List<User>();

        public async Task CreateAsync(User user)
            => await Task.Run(() => _users.Add(user));

        public async Task<IEnumerable<User>> GetAsync(int page, int pageSize)
            => await Task.Run(() => _users.Skip((page - 1) * pageSize).Take(pageSize));
    }
}
