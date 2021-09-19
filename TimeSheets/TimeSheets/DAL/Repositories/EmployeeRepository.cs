using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL.Repositories.Interfaces;
using TimeSheets.Entities;

namespace TimeSheets.DAL.Repositories
{
    internal sealed class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IList<Employee>> GetAllAsync() => await _db.Employees.ToListAsync();

        public async Task<Employee> GetOneAsync(int id) => await _db.Employees.FindAsync(id);

        public async Task CreateAsync(Employee obj)
        {
            _db.Employees.Add(obj);
            await _db.SaveChangesAsync();
        }
    }
}