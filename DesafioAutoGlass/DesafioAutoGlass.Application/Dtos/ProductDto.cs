using DesafioAutoGlass.Domain.Entities;
using System;

namespace DesafioAutoGlass.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime? ManufacturingDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }
    }
}
