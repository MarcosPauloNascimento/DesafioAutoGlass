using DesafioAutoGlass.Domain.Core.Interfaces.Repositories;
using DesafioAutoGlass.Domain.Entities;
using DesafioAutoGlass.Infrastructure.Data;
using DesafioAutoGlass.Infrastructure.Data.Repositories;

namespace TesteTecnico.Infrastructure.Data.Repositories
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
