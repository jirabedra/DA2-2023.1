using Entities;
using Moq;
using Repositories.Interfaces;

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
            var userService = new UserService(userRepository.Object);
            userRepository.Setup(u => u.AddUser(It.IsAny<User>())).Returns(user);

            //Act 
            var result = userService.AddNewUser(user);

            //Assert
            userRepository.VerifyAll();
            Assert.AreEqual(user, result);
        }

        [TestMethod]
        public void AddNewUserWithEmptyFirstName()
        {
            //Arrange 
            Exception exceptionResult = null;
            var userRepository = new Mock<IUserRepository>();
            try
            {
                User user = new User()
                {
                    FirstName = "",
                    LastName = "Lopez"
                };
                var userService = new UserService(userRepository.Object);

                //Act 
                var result = userService.AddNewUser(user);
            }
            catch (Exception ex)
            {
                exceptionResult = ex;
            }

            //Assert
            userRepository.VerifyAll();
            Assert.IsNotNull(exceptionResult);
            Assert.IsInstanceOfType(exceptionResult, typeof(ArgumentException));
            Assert.AreEqual(exceptionResult.Message, "Nombre vacio");

        }
    }
}