using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TimeSheets.DAL.Repositories.Interfaces;
using TimeSheets.DAL.Services.Interfaces;
using TimeSheets.DTO;
using TimeSheets.Entities;

namespace TimeSheets.DAL.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _repository;
        private readonly IMapper _mapper;

        public ContractService(IContractRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IList<ContractDto>> GetAllAsync()
        {
            IList<Contract> contracts = await _repository.GetAllAsync();

            IList<ContractDto> output = new List<ContractDto>();
            foreach (var contract in contracts)
            {
                output.Add(_mapper.Map<ContractDto>(contract));
            }

            return output;
        }

        public async Task<ContractDto> GetOneAsync(int id) => _mapper.Map<ContractDto>(await _repository.GetOneAsync(id));

        public async Task CreateAsync(Contract obj) => await _repository.CreateAsync(obj);

        public async Task FinishContractAsync(int id) => await _repository.FinishContractAsync(id);
    }
}