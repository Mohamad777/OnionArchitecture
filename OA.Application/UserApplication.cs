using OA.Application.Contracts.User;
using OA.Domain.Services;
using OA.Domain.UserAgg;
using System.Linq;

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

            //foreach (var item in userlist)
            //{
            //    userviewmodellist.Add(new UserListViewModel()
            //    {
            //        Phone = item.Phone,
            //        Email = item.Email,
            //        DateCreated = item.DateCreated.ToString()
            //    });
            //}
            //return userviewmodellist;

            return (from item in userlist
                    select new UserListViewModel()
                    {
                        Phone = item.Phone,
                        Email = item.Email,
                        DateCreated = item.DateCreated.ToString()
                    }).ToList();
        }

        public void Add(AddUserCommand command)
        {
            var user = new User(command.Phone, command.Email, command.Password, _userValidatorService);
            _userRepository.Insert(user);
        }

        public void Edit(EditUserCommand command)
        {
            var model = _userRepository.GetBy(command.Id);
            model.Edit(command.Phone, command.Email, command.Password, command.IsDeleted, _userValidatorService);
            _userRepository.Save();
        }

        public UserListViewModel GetBy(long id)
        {
            throw new NotImplementedException();
        }
    }
}
