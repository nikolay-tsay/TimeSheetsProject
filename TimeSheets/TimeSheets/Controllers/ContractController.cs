using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TimeSheets.DAL.Services.Interfaces;
using TimeSheets.Entities;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("api/contracts")]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _service;

        public ContractController(IContractService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("ContractController: GetAll method called");
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ContractController: GetAll method failed");
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            Log.Information($"ContractController: GetOne method called. Input - {id}");
            try
            {
                return Ok(await _service.GetOneAsync(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ContractController: GetOne method failed");
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateContract([FromBody] Contract contract)
        {
            Log.Information($"ContractController: Create method called. Input - {contract}");
            try
            {
                await _service.CreateAsync(contract);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex,"ContractController: Create method failed");
                return Problem(ex.Message);
            }
        }

        [HttpPatch]
        [Route("finish")]
        public async Task<IActionResult> FinishContract([FromRoute] int id)
        {
            Log.Information($"ContractController: FinishContract method called. Input - {id}");
            try
            {
                await _service.FinishContractAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex,"ContractController: FinishContract method failed");
                return Problem(ex.Message);
            }
        }
    }
}