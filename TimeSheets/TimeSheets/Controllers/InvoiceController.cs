using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TimeSheets.DAL.Services.Interfaces;
using TimeSheets.Entities;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("InvoiceController: GetAll method called");
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                Log.Information(ex,"InvoiceController: GetAll method failed");
                return Problem(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            Log.Information($"InvoiceController: GetOne method called.Input - {id}");
            try
            {
                return Ok(await _service.GetOneAsync(id));
            }
            catch (Exception ex)
            { 
                Log.Information(ex,"InvoiceController: GetOne method failed");
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateInvoice([FromBody] Invoice invoice)
        {
            Log.Information($"InvoiceController: Create method called.Input - {invoice}");
            try
            {
                _service.CreateAsync(invoice);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Information(ex,"InvoiceController: Create method failed");
                return Problem(ex.Message);
            }
        }

        [HttpPatch]
        [Route("close")]
        public async Task<IActionResult> CloseInvoice([FromRoute] int id)
        {
            Log.Information($"InvoiceController: Close method called.Input - {id}");
            try
            {
                await _service.CloseInvoiceAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Information(ex,"InvoiceController: Close method failed");
                return Problem(ex.Message);
            }
        }
    }
}