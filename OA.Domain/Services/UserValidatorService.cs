using OA.Domain.Exceptions;
using OA.Domain.UserAgg;

namespace OA.Domain.Services
{
    public class UserValidatorService : IUserValidatorService
    {
        private readonly IUserRepository _userRepository;

        public UserValidatorService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CheckPhoneExistance(string phone)
        {
            if (_userRepository.PhoneExists(phone))
            {
                throw new AlreadyExistsRecordException($"The phone number {phone} is already exists in database.");
            }
        }
    }
}