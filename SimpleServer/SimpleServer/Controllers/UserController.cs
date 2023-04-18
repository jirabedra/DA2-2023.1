using Domain.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace SimpleServer
{
    [ApiController]
    [Route("api/users")]
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult PostNewUser([FromBody] UserInModel userInModel)
        {
            User user = userInModel.ToEntity();
            User result = _userService.AddNewUser(user);

            UserOutModel userOut = new UserOutModel(result);

            return new OkObjectResult(userOut);
        }
    }
}