using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.UserAgg
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetBy(long id);
        void Add(User entity);
        void Edit(User user);
        void Save();

        bool PhoneExists(string phone);
    }
}
