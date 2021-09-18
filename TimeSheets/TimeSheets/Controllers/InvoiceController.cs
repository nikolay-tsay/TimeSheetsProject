using Microsoft.AspNetCore.Mvc;
using TimeSheets.Entities;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : ControllerBase
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
        public IActionResult CreateInvoice([FromBody] Invoice invoice)
        {
            return Ok();
        }

        [HttpPatch]
        [Route("close")]
        public IActionResult CloseInvoice([FromRoute] int id)
        {
            return Ok();
        }
    }
}