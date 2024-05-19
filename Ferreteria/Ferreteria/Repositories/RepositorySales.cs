using Ferreteria.Data;
using Ferreteria.Models;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Repositories
{
    public class RepositorySales : IRepositorySales
    {
        private readonly FerreteriaDbContext _context;
        public RepositorySales(FerreteriaDbContext context)
        {
            _context = context;
        }
        public async Task<Sale> Add(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
            return sale;
        }
        public async Task Delete(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Sale?> Get(int id)
        {
            return await _context.Sales.Include(s => s.SaleDetails).Where(sd => sd.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Sale>> GetAll()
        {
            return await _context.Sales.ToListAsync();
        }
        public async Task Update(int id, Sale sale)
        {
            var currentSale = await _context.Sales.FindAsync(id);
            if (currentSale != null)
            {
                currentSale.SaleDate = sale.SaleDate;
                currentSale.TotalAmount = sale.TotalAmount;
                currentSale.SaleDetails = sale.SaleDetails;
                await _context.SaveChangesAsync();
            }
        }
    }
}
