using OA.Domain.Services;

namespace OA.Domain.UserAgg
{
    public class User : BaseModel<long>
    {
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsDeleted { get; set; }

        public User()
        {
        }

        public User(string phone, string email, string password, IUserValidatorService userValidatorService)
        {
            CheckAndSetModel(phone, email, password, false, userValidatorService);
        }

        public void Edit(string phone, string email, string password, bool isDeleted, IUserValidatorService userValidatorService)
        {
            CheckAndSetModel(phone, email, password, isDeleted, userValidatorService);
        }

        private void CheckAndSetModel(string phone, string email, string password, bool isDeleted, IUserValidatorService userValidatorService)
        {
            GaurdAgainstEmptyValue(Phone);
            GaurdAgainstEmptyValue(Email);
            GaurdAgainstEmptyValue(Password);
            userValidatorService.CheckPhoneExistance(Phone);
            Phone = phone;
            Email = email;
            Password = password;
            IsDeleted = IsDeleted;
        }

        void GaurdAgainstEmptyValue(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("user argument");
        }

    }
}
