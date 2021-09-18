using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL.Repositories.Interfaces;
using TimeSheets.Entities;

namespace TimeSheets.DAL.Repositories
{
    internal sealed class ContractRepository : IContractRepository
    {
        private readonly ApplicationDbContext _db;

        public ContractRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<IList<Contract>> GetAll()
        {
            return await _db.Contracts.ToListAsync();
        }

        public async Task<Contract> GetOne(int id)
        {
            return await _db.Contracts.FindAsync(id);
        }

        public async Task Create(Contract obj)
        {
            _db.Contracts.Add(obj);
            await _db.SaveChangesAsync();
        }

        public async Task FinishContract(int id)
        {
            var contract = new Contract() {Id = id};
            _db.Contracts.Attach(contract);
            _db.Entry(contract).Property(x => x.IsFinished).IsModified = true;
            
            await _db.SaveChangesAsync();
        }
    }
}