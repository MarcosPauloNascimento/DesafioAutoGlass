using DesafioAutoGlass.Domain.Entities;

namespace DesafioAutoGlass.Domain.Core.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product> GetProduct(int id);
        
        Task<IEnumerable<Product>> GetProducts();

        Task<IEnumerable<Product>> GetProducts(string filter);

        Task<IEnumerable<Product>> GetProductsBySupplierId(int supplierId);
    }
}
