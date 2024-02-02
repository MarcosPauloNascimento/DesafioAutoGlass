using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioAutoGlass.Domain.Entities
{
    public class Supplier
    {
        public Supplier()
        {
            
        }
        public Supplier(string description, string cnpj)
        { 
            this.Description = description;
            this.CNPJ = cnpj;
        }

        [Key]
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public string CNPJ { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
