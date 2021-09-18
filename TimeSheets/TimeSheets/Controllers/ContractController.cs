using Microsoft.AspNetCore.Mvc;
using TimeSheets.Entities;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("api/contracts")]
    public class ContractController : ControllerBase
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
        [Route("create")]
        public IActionResult CreateContract([FromBody] Contract contract)
        {
            return Ok();
        }

        [HttpPatch]
        [Route("finish")]
        public IActionResult FinishContract([FromRoute] int id)
        {
            return Ok();
        }
    }
}