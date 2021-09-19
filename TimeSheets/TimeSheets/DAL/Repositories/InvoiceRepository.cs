using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL.Repositories.Interfaces;
using TimeSheets.Entities;

namespace TimeSheets.DAL.Repositories
{
    internal sealed class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _db;

        public InvoiceRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<IList<Invoice>> GetAllAsync()
        {
            return await _db.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetOneAsync(int id)
        {
            return await _db.Invoices.FindAsync(id);
        }

        public async Task CreateAsync(Invoice obj)
        {
            _db.Invoices.Add(obj);
            await _db.SaveChangesAsync();
        }

        //public async Task CloseInvoice(int id)
        //{
        //    var invoice = await _db.Invoices.FindAsync(id);
        //    invoice.IsClosed = true;
        //    _db.Entry(invoice).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //}
    }
}