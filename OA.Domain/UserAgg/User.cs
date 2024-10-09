using OA.Domain.Services;

namespace OA.Domain.UserAgg
{
    public class User
    {
        public long Id { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public User(string phone, string email, string password, IUserValidatorService userValidatorService)
        {
            GaurdAgainstEmptyValue(Phone);
            GaurdAgainstEmptyValue(Email);
            GaurdAgainstEmptyValue(Password);

            userValidatorService.CheckPhoneExistance(Phone);

            Phone = phone;
            Email = email;
            Password = password;
            IsDeleted = false;
            DateCreated = DateTime.Now;
        }

        void GaurdAgainstEmptyValue(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("user argument");
        }

    }
}
