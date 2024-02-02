using DesafioAutoGlass.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioAutoGlass.Application.Interfaces
{
    public interface IApplicationSupplierServices
    {
        Task<bool> Add(SupplierDto supplierDto);

        Task<bool> Update(SupplierDto supplierDto);

        Task Delete(SupplierDto supplierDto);

        Task<SupplierDto> GetById(int id);

        Task<IEnumerable<ProductDto>> GetProductsBySuplierId(int id);

        Task<IEnumerable<SupplierDto>> GetAll();
    }
}
