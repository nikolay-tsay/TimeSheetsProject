using Microsoft.AspNetCore.Mvc;
using TimeSheets.Entities;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        
        [HttpGet]
        [Route("list")]
        public IActionResult GetAll()
        {
            return Ok();
        }
        
        [HttpGet]
        [Route("get")]
        public IActionResult GetOne([FromRoute] int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterEmployee([FromBody] Employee employee)
        {
            return Ok();
        }
    }
}