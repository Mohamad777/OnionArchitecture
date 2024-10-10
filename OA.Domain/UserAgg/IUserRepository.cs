namespace OA.Domain.UserAgg
{
    public interface IUserRepository : IRepository<User>
    {
        bool PhoneExists(string phone);
        IEnumerable<User> GetActiveUsers();
    }
}
