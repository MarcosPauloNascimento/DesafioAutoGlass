using DesafioAutoGlass.Domain.Core.Interfaces.Repositories;
using DesafioAutoGlass.Domain.Entities;

namespace DesafioAutoGlass.Infrastructure.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly SqlDbContext _context;

        public ProductRepository(SqlDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
