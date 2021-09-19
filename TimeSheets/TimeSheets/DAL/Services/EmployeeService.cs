using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TimeSheets.DAL.Repositories.Interfaces;
using TimeSheets.DAL.Services.Interfaces;
using TimeSheets.DTO;
using TimeSheets.Entities;

namespace TimeSheets.DAL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IList<EmployeeDto>> GetAllAsync()
        {
            IList<Employee> employees = await _repository.GetAllAsync();

            IList<EmployeeDto> output = new List<EmployeeDto>();
            foreach (var employee in employees)
            {
                output.Add(_mapper.Map<EmployeeDto>(employee));
            }

            return output;
        }

        public async Task<EmployeeDto> GetOneAsync(int id) =>
            _mapper.Map<EmployeeDto>(await _repository.GetOneAsync(id));

        public async Task CreateAsync(Employee obj) =>
            await _repository.CreateAsync(obj);
    }
}