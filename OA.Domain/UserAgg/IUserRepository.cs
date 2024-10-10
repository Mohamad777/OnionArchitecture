using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.UserAgg
{
    public interface IUserRepository : IRepository<User>
    {
        bool PhoneExists(string phone);
        IEnumerable<User> GetActiveUsers();
    }
}
