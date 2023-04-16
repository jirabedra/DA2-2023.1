namespace Domain
{
    public class UserService
    {
        private global::Moq.Mock<IUserRepository> userRepository;

        public UserService(global::Moq.Mock<IUserRepository> userRepository)
        {
            this.userRepository = userRepository;
        }
    }
}