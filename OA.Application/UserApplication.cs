using OA.Application.Contracts.User;
using OA.Domain;
using OA.Domain.Services;
using OA.Domain.UserAgg;

namespace OA.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidatorService _userValidatorService;
        private readonly IUnitOfWork _unitOfWork;

        public UserApplication(IUserRepository userRepository, IUserValidatorService userValidatorService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userValidatorService = userValidatorService;
            _unitOfWork = unitOfWork;
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
            _unitOfWork.BeginTran();
            var user = new User(command.Phone, command.Email, command.Password, _userValidatorService);
            _userRepository.Insert(user);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditUserCommand command)
        {
            _unitOfWork.BeginTran();
            var model = _userRepository.GetBy(command.Id);
            model.Edit(command.Phone, command.Email, command.Password, command.IsDeleted, _userValidatorService);
            _unitOfWork.CommitTran();
            //_userRepository.Save();
        }

        public UserListViewModel GetBy(long id)
        {
            throw new NotImplementedException();
        }
    }
}
