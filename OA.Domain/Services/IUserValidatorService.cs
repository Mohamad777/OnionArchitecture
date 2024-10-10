namespace OA.Domain.Services
{
    public interface IUserValidatorService
    {
        void CheckPhoneExistance(string phone);
    }
}
