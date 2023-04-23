
using Domain.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
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

            UserOutModel userExpected = new UserOutModel(user);

            var aUserService = new Mock<IUserService>(MockBehavior.Strict);
            aUserService.Setup(u => u.AddNewUser(It.IsAny<User>())).Returns(user);
            UserController aUserController = new UserController(aUserService.Object);

            //Act
            var result = aUserController.PostNewUser(aUserIn);

            //Assert
            aUserService.VerifyAll();
            var resultObject = result as OkObjectResult;
            var userResult = resultObject.Value as UserOutModel;

            Assert.AreEqual(userExpected.FirstName, userResult.FirstName);
        }
    }
}
