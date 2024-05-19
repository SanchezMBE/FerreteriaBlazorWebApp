using Ferreteria.Models;

namespace Ferreteria.Repositories
{
    public interface IRepositorySales
    {
        Task<List<Sale>> GetAll();
        Task<Sale> Get(int id);
        Task<Sale> Add(Sale sale);
        Task Update(int id, Sale sale);
        Task Delete(int id);
    }
}
