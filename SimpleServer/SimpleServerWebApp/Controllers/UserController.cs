using Domain.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using SimpleServerWebApp.Filters;

namespace SimpleServer
{
    [ExceptionFilter]
    [AuthenticationFilter]
    [ApiController]
    [Route("api/users")]
    public class UserController
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpPost]
        public IActionResult PostNewUser([FromBody] UserInModel userInModel)
        {
            var userLogged = (User)_httpContextAccessor.HttpContext.Items["user"];
            User user = userInModel.ToEntity();
            User result = _userService.AddNewUser(user);

            UserOutModel userOut = new UserOutModel(result);

            return new OkObjectResult(userOut);


        }
    }
}