using Domain.interfaces;
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
            var user = userInModel.ToEntity();
            var result = _userService.AddNewUser(user);

            var userOut = new UserOutModel(result);

            return new OkObjectResult(userOut);
        }
    }
}