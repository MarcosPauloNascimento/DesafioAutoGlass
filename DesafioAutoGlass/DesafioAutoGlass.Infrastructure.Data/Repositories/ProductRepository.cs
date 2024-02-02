using DesafioAutoGlass.Domain.Core.Interfaces.Repositories;
using DesafioAutoGlass.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioAutoGlass.Infrastructure.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly SqlDbContext _context;

        public ProductRepository(SqlDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.AsNoTracking().Include(f => f.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.AsNoTracking().Include(f => f.Supplier)
                .OrderBy(p => p.Description).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts(string filter)
        {
            IQueryable<Product> productQuery = _context.Products;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                productQuery = productQuery
                    .Where(x => x.Description.Contains(filter) ||
                                x.ManufacturingDate.ToString().Contains(filter) ||
                                x.ExpirationDate.ToString().Contains(filter)
                    );
            }

            var products =  await productQuery
                .AsNoTracking()                
                .Include(f => f.Supplier)
                .OrderBy(p => p.Description).ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplierId(int supplierId)
        {
            return await Get(p => p.SupplierId == supplierId);
        }
    }

}
