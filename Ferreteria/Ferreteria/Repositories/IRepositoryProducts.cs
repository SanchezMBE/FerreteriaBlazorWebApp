using Ferreteria.Models;

namespace Ferreteria.Repositories
{
    public interface IRepositoryProducts
    {
        Task<List<Product>> GetAll();
        Task<Product> Get(int id);
        Task<Product> Add(Product product);
        Task Update(int id, Product product);
        Task Delete(int id);
    }
}
