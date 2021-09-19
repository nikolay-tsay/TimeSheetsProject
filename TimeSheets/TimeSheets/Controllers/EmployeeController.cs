using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TimeSheets.DAL.Services.Interfaces;
using TimeSheets.Entities;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("EmployeeController: GetAll method called");
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                Log.Information(ex,"EmployeeController: GetAll method failed");
                return Problem(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            Log.Information($"EmployeeController: GetOne method called.Input - {id}");
            try
            {
                return Ok(await _service.GetOneAsync(id));
            }
            catch (Exception ex)
            {
                Log.Information(ex,"EmployeeController: GetOne method failed");
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterEmployee([FromBody] Employee employee)
        {
            Log.Information($"EmployeeController: Register method called.Input - {employee}");
            try
            {
                await _service.CreateAsync(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Information(ex,"EmployeeController: GetOne method failed");
                return Problem(ex.Message);
            }
        }
    }
}