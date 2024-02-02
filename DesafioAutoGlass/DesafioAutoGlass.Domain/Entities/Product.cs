using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioAutoGlass.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            
        }
        public Product(string description, 
            bool status, 
            DateTime manufacturingDate,
            DateTime expirationDate)
        {
            this.Description = description;
            this.Status = status;
            this.ManufacturingDate = manufacturingDate;
            this.ExpirationDate = expirationDate;
                
        }
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
