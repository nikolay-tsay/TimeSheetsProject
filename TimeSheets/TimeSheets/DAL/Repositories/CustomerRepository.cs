using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL.Repositories.Interfaces;
using TimeSheets.Entities;

namespace TimeSheets.DAL.Repositories
{
    internal sealed class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<IList<Customer>> GetAllAsync()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Customer> GetOneAsync(int id)
        {
            return await _db.Customers.FindAsync(id);
        }

        public async Task CreateAsync(Customer obj)
        {
            _db.Customers.Add(obj);
            await _db.SaveChangesAsync();
        }
    }
}