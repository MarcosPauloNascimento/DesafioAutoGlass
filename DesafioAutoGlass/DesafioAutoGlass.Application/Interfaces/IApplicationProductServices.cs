using DesafioAutoGlass.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioAutoGlass.Application.Interfaces
{
    public interface IApplicationProductServices
    {
        Task<bool> Add(ProductDto userDto);

        Task<bool> Update(ProductDto userDto);

        Task Delete(ProductDto userDto);

        Task<ProductDto> GetById(int id);

        Task<IEnumerable<ProductDto>> GetAll();

    }
}
