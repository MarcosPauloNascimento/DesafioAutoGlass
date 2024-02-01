using DesafioAutoGlass.Domain.Core.Interfaces.Repositories;
using DesafioAutoGlass.Domain.Core.Interfaces.Services;
using DesafioAutoGlass.Domain.Entities;

namespace DesafioAutoGlass.Domain.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product domain)
        {
            await _productRepository.Add(domain);
        }

        public async Task Update(Product domain)
        {
            await _productRepository.Update(domain);
        }

        public async Task Delete(Product domain)
        {
            await _productRepository.Delete(domain);
        }

        public async Task<Product> Get(int id)
        {
            return await _productRepository.Get(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public void Detach(Product domain)
        {
            _productRepository.Detach(x => x.Id == domain.Id);
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}
