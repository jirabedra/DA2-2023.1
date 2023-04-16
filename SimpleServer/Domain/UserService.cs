using Domain.interfaces;
using Entities;
using Repositories.Interfaces;

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
            throw new NotImplementedException();
        }
    }
}