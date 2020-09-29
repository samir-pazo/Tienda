using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal Stock { get; set; }

        //producto pertenece a una categoria
        public int CategoryId { get; set; }


        // esta propiedad para traer el nombre de la categoria 
        public string CategoryName { get; set; }
    }
}
