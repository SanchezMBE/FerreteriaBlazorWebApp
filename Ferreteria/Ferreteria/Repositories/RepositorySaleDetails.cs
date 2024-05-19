using Ferreteria.Data;
using Ferreteria.Models;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Repositories
{
    public class RepositorySaleDetails : IRepositorySaleDetails
    {
        private readonly FerreteriaDbContext _context;
        public RepositorySaleDetails(FerreteriaDbContext context)
        {
            _context = context;
        }
        public async Task<SaleDetail> Add(SaleDetail saleDetail)
        {
            await _context.SaleDetails.AddAsync(saleDetail);
            await _context.SaveChangesAsync();
            return saleDetail;
        }

        public async Task Delete(int id)
        {
            var saleDetail = await _context.SaleDetails.FindAsync(id);
            if (saleDetail != null)
            {
                _context.SaleDetails.Remove(saleDetail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<SaleDetail?> Get(int id)
        {
            return await _context.SaleDetails.FindAsync(id);
        }

        public async Task<List<SaleDetail>> GetAll()
        {
            return await _context.SaleDetails.ToListAsync();
        }

        public async Task Update(int id, SaleDetail saleDetail)
        {
            var currentSaleDetail = await _context.SaleDetails.FindAsync(id);
            if (currentSaleDetail != null)
            {
                currentSaleDetail.Quantity = saleDetail.Quantity;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<SaleDetail>> GetBySaleId(int saleId)
        {
            return await _context.SaleDetails.Where(sd => sd.SaleId == saleId).Include(sd => sd.Product).ToListAsync();
        }
    }
}
