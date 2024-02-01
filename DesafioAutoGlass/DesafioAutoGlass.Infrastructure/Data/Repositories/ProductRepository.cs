using DesafioAutoGlass.Domain.Core.Interfaces.Repositories;
using DesafioAutoGlass.Domain.Entities;
using DesafioAutoGlass.Infrastructure.Data;
using DesafioAutoGlass.Infrastructure.Data.Repositories;

namespace TesteTecnico.Infrastructure.Data.Repositories
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
