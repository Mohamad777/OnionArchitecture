using OA.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Infrastructure.EFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MasterContext _masterContext;

        public UserRepository(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }

        public List<User> GetAll()
        {
            return _masterContext.Users.ToList();
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }


        public User? GetBy(long id)
        {
            return _masterContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _masterContext.SaveChanges();
        }

        public bool PhoneExists(string phone)
        {
            return _masterContext.Users.Any(x => x.Phone == phone);
        }
    }
}
