using Microsoft.EntityFrameworkCore;
using OA.Domain.UserAgg;

namespace OA.Infrastructure.EFCore.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MasterContext _masterContext;

        public UserRepository(MasterContext dbContext) : base(dbContext)
        {
            _masterContext = dbContext;
        }

        public IEnumerable<User> GetActiveUsers()
        {
            // Active field is not yet available. using IsDeleted instead.
            return _masterContext.Users.Where(x => x.IsDeleted == false).AsNoTracking().ToList();
        }

        public bool PhoneExists(string phone)
        {
            return _masterContext.Users.Any(x => x.Phone == phone);
        }
    }
}
