namespace OA.Application.Contracts.User
{
    public class EditUserCommand : AddUserCommand
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}