using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL.Repositories.Interfaces;
using TimeSheets.DAL.Services.Interfaces;
using TimeSheets.DTO;
using TimeSheets.Entities;

namespace TimeSheets.DAL.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext _db;
        private readonly IInvoiceRepository _repository;
        private readonly IMapper _mapper;
        
        public InvoiceService(ApplicationDbContext db, IInvoiceRepository repository, IMapper mapper)
        {
            _db = db;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<InvoiceDto>> GetAllAsync()
        {
            IList<Invoice> invoices = await _repository.GetAllAsync();

            IList<InvoiceDto> output = new List<InvoiceDto>();

            foreach (var invoice in invoices)
            {
                output.Add(_mapper.Map<InvoiceDto>(invoice));
            }

            return output;
        }

        public async Task<InvoiceDto> GetOneAsync(int id) => 
            _mapper.Map<InvoiceDto>(await _repository.GetOneAsync(id));
        

        public async Task CreateAsync(Invoice obj )=> 
            await _repository.CreateAsync(obj);
        

        public async Task CloseInvoiceAsync(int id)
        {
            var invoice = await _db.Invoices.FindAsync(id);
            
            foreach (var contract in invoice.Contracts)
            {
                if (!contract.IsFinished) continue;
                
                invoice.TotalHours += (contract.DateOfFinish - contract.DateOfCreation).Hours;
                invoice.TotalPrice += contract.Price;
            }

            _db.Entry(invoice).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }
    }
}