using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SimpleServer.Controllers
{
    [ApiController]
    [Route("api/myController2")]
    public class SimpleController : ControllerBase
    {

        private IGreetingObject _greetingObject;

        public SimpleController(IGreetingObject greetingObject)
        {
            _greetingObject = greetingObject;
        }

        [HttpGet("{someMessage}")]
        public IActionResult Get([FromRoute] string someMessage)
        {
            return StatusCode(500, _greetingObject.GetOnGetAction(someMessage));
        }

        [HttpPost]
        public IActionResult Post([FromBody] SomeDto someDto)
        {
            return new OkObjectResult(_greetingObject.GetOnPostAction(someDto.Data));
        }

        [HttpPut]
        public IActionResult Put([FromQuery] string someString, [FromBody] SomeDto someDto)
        {
            return new OkObjectResult(_greetingObject.GetOnPutAction(someString, someDto.Data));
        }

        [HttpDelete]
        public IActionResult Delete([FromHeader] string someString)
        {
            return new OkObjectResult(_greetingObject.GetOnDeleteAction(someString));
        }
    }
}