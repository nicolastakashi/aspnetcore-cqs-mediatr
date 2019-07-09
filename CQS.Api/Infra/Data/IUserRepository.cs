using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQS.Api.Entities;

namespace CQS.Api.Infra.Data
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<IEnumerable<User>> GetAsync(int page, int pageSize);
    }
}
