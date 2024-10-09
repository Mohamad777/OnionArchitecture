using OA.Application.Contracts.User;
using OA.Domain.Services;
using OA.Domain.UserAgg;

namespace OA.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidatorService _userValidatorService;

        public UserApplication(IUserRepository userRepository, IUserValidatorService userValidatorService)
        {
            _userRepository = userRepository;
            _userValidatorService = userValidatorService;
        }

        public List<UserListViewModel> GetAll()
        {
            var userlist = _userRepository.GetAll();
            var userviewmodellist = new List<UserListViewModel>();
            foreach (var item in userlist)
            {
                userviewmodellist.Add(new UserListViewModel()
                {
                    Phone = item.Phone,
                    Email = item.Email,
                    DateCreated = item.DateCreated.ToString()
                });
            }
            return userviewmodellist;
        }

        public void Add(AddUserCommand command)
        {
            var user = new User(command.Phone, command.Email, command.Password, _userValidatorService);
            _userRepository.Add(user);
        }

        public void Edit(EditUserCommand command)
        {
            throw new NotImplementedException();
        }

        public UserListViewModel GetBy(long id)
        {
            throw new NotImplementedException();
        }
    }
}
