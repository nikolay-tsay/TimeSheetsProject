using System;
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
        
        public async Task<IList<Contract>> GetAllAsync() => await _db.Contracts.ToListAsync();

        public async Task<Contract> GetOneAsync(int id) => await _db.Contracts.FindAsync(id);

        public async Task CreateAsync(Contract obj)
        {
            _db.Contracts.Add(obj);
            await _db.SaveChangesAsync();
        }

        public async Task FinishContractAsync(int id)
        {
            var contract = await _db.Contracts.FindAsync(id);
            contract.IsFinished = true;
            contract.DateOfFinish = DateTimeOffset.Now;
            
            var employee = await _db.Employees.FindAsync(contract.EmployeeId);
            contract.HoursSpent = CountHours(contract.DateOfCreation, contract.DateOfFinish);
            
            contract.Price = CountPrice(contract.HoursSpent, employee.Rate);
            
            _db.Entry(contract).State = EntityState.Modified;
            
            await _db.SaveChangesAsync();
        }
        
        private int CountHours(DateTimeOffset firstDate, DateTimeOffset secondDate) => (secondDate - firstDate).Hours;

        private decimal CountPrice(int hours, decimal rate) => rate * hours;
    }
}