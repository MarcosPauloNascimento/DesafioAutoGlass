using DesafioAutoGlass.Domain.Core.Interfaces.Repositories;
using DesafioAutoGlass.Domain.Core.Interfaces.Services;
using DesafioAutoGlass.Domain.Entities;

namespace DesafioAutoGlass.Domain.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task Add(Supplier domain)
        {
            await _supplierRepository.Add(domain);
        }

        public async Task Update(Supplier domain)
        {
            await _supplierRepository.Update(domain);
        }

        public async Task Delete(Supplier domain)
        {
            await _supplierRepository.Delete(domain);
        }

        public async Task<Supplier> Get(int id)
        {
            return await _supplierRepository.Get(id);
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await _supplierRepository.GetAll();
        }

        public void Detach(Supplier domain)
        {
            _supplierRepository.Detach(x => x.Id == domain.Id);
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
        }
    }
}
