namespace OA.Application.Contracts.User
{
    public class AddUserCommand : UserListViewModel
    {
        public string? Password { get; set; }
    }
}