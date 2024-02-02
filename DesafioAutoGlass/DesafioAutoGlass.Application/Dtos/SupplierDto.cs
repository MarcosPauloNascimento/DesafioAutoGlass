using System.Collections.Generic;

namespace DesafioAutoGlass.Application.Dtos
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string CNPJ { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
