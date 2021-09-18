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
        
        public async Task<IList<Invoice>> GetAll()
        {
            return await _db.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetOne(int id)
        {
            return await _db.Invoices.FindAsync(id);
        }

        public async Task Create(Invoice obj)
        {
            _db.Invoices.Add(obj);
            await _db.SaveChangesAsync();
        }

        public async Task CloseInvoice(int id)
        {
            var invoice = new Invoice() {Id = id};
            _db.Invoices.Attach(invoice);
            _db.Entry(invoice).Property(x => x.IsClosed).IsModified = true;

            await _db.SaveChangesAsync();
        }
    }
}