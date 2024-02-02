using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioAutoGlass.Domain.Entities
{
    public class Supplier
    {
        public Supplier(String description, string cnpj)
        { 
            Description = description;
            CNPJ = cnpj;
        }

        [Key]
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public string CNPJ { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
