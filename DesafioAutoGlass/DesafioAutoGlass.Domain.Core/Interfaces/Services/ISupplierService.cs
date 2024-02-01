using DesafioAutoGlass.Domain.Entities;

namespace DesafioAutoGlass.Domain.Core.Interfaces.Services
{
    public interface ISupplierService : IDisposable
    {
        Task Add(Supplier supplier);

        Task Update(Supplier supplier);

        Task Delete(Supplier supplier);

        Task<Supplier> Get(int id);

        Task<IEnumerable<Supplier>> GetAll();

        void Detach(Supplier supplier);
    }
}
