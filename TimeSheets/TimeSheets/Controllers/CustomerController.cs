using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TimeSheets.DAL.Services.Interfaces;
using TimeSheets.Entities;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("CustomerController: GetAll method called");
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                Log.Error(ex,"CustomerController: GetAll method failed");
                return Problem(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            Log.Information($"CustomerController: GetOne method called. Input - {id}");
            try
            {
                return Ok(await _service.GetOneAsync(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex,"CustomerController: GetOne method failed");
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody] Customer customer)
        {
            Log.Information($"CustomerController: Register method called. Input - {customer}");
            try
            {
                await _service.CreateAsync(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex,"CustomerController: Register method failed");
                return Problem(ex.Message);
            }
        }
    }
}