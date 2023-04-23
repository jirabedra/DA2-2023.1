using Domain.Interfaces;
using Entities;
using DataAccess.Interfaces;

namespace Domain
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User AddNewUser(User user)
        {
            user.Validate();
            user.Timestamp = DateTime.Now;
            user.Token = Guid.NewGuid();
            return userRepository.AddUser(user);
        }

        public User GetUserByToken(Guid aToken)
        {
            return userRepository.Get((User u)=> u.Token == aToken);
        }

        public bool IsValidToken(Guid aToken)
        {
            return userRepository.Exist((User u) => u.Token == aToken);
        }
    }
}