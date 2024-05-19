using Ferreteria.Models;

namespace Ferreteria.Repositories
{
    public interface IRepositorySaleDetails
    {
        Task<List<SaleDetail>> GetAll();
        Task<SaleDetail> Get(int id);
        Task<SaleDetail> Add(SaleDetail saleDetail);
        Task Update(int id, SaleDetail saleDetail);
        Task Delete(int id);
        Task<List<SaleDetail>> GetBySaleId(int saleId);
    }
}
