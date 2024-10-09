namespace OA.Application.Contracts.User
{
    public interface IUserApplication
    {
        List<UserListViewModel> GetAll();
        UserListViewModel GetBy(long id);
        void Add(AddUserCommand command);
        void Edit(EditUserCommand command);
    }
}
