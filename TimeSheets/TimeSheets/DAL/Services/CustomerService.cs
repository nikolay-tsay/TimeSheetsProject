using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TimeSheets.DAL.Repositories.Interfaces;
using TimeSheets.DAL.Services.Interfaces;
using TimeSheets.DTO;
using TimeSheets.Entities;

namespace TimeSheets.DAL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<CustomerDto>> GetAllAsync()
        {
            IList<Customer> customers = await _repository.GetAllAsync();

            IList<CustomerDto> output = new List<CustomerDto>();
            foreach (var customer in customers)
            {
                output.Add(_mapper.Map<CustomerDto>(customer));
            }

            return output;
        }


        public async Task<CustomerDto> GetOneAsync(int id) => 
            _mapper.Map<CustomerDto>(await _repository.GetOneAsync(id));

        public async Task CreateAsync(Customer obj) => 
            await _repository.CreateAsync(obj);
    }
}