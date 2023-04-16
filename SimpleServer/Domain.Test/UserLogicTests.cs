using Entities;
using Moq;

namespace Domain.Test
{
    [TestClass]
    public class UserLogicTests
    {
        [TestMethod]
        public void AddNewUserCorrect()
        {
            //Arrange 
            User user = new User()
            {
                FirstName = "Pepe",
                LastName = "Lopez"
            };

            var userRepository = new Mock<IUserRepository>(MockBehavior.Strict);
            var userService = new UserService(userRepository)

            //Act 


            //Assert

        }
    }
}