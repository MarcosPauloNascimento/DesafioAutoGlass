using DesafioAutoGlass.Domain.Core.Interfaces.Repositories;
using DesafioAutoGlass.Domain.Entities;
using DesafioAutoGlass.Infrastructure.Data;

namespace DesafioAutoGlass.Infrastructure.Data.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        private readonly SqlDbContext _context;

        public SupplierRepository(SqlDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
