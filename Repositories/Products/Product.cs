using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }= default!;//hala null değer alabilir ama default! ile null olamaz dedik
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
