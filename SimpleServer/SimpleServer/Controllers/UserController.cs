using Microsoft.AspNetCore.Mvc;

namespace SimpleServer
{
    [ApiController]
    [Route("api/users")]
    public class UserController
    {
        [HttpPost]
        public ActionResult<UserOutModel> PostNewUser([FromBody] UserInModel userInModel)
        {
            throw new NotImplementedException();
        }
    }
}