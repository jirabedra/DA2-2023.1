
using Domain.interfaces;
using Entities;
using Moq;

namespace SimpleServer.test
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void AddingNewUser()
        {
            //Arrange
            UserInModel aUserIn = new UserInModel()
            {
                FirstName = "Pepe",
                LastName = "Lopez"
            };
            User user = new User()
            {
                FirstName = "Pepe",
                LastName = "Lopez"
            };

            UserOutModel userExpected = new UserOutModel()
            {
                FirstName = "Pepe",
                LastName = "Lopez"
            };

            var aUserService = new Mock<IUserService>(MockBehavior.Strict);
            UserController aUserController = new UserController();
            aUserService.Setup(u => u.AddNewUser(It.IsAny<User>())).Returns(user);

            //Act
            var result = aUserController.PostNewUser(aUserIn);

            //Assert
            aUserService.VerifyAll();
            Assert.AreEqual(userExpected.FirstName, result.Value.FirstName);
        }
    }
}
