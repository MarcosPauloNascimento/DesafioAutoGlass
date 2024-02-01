using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutoGlass.Domain.Entities
{
    public class Supplier
    {
        public Supplier() { }

        public int Id { get; set; }
        public string Description { get; set; }
        public string CNPJ { get; set; }
        public List<Product> Products { get; set; }
    }
}
