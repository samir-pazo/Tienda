using System.Collections.Generic;
using Data;
using Entities;

namespace BusinessLogic
{
    public class LProduct
    {

        public List<Product> GetAll()
        {
            return new DProduct().GetAll();
        }


        public List<Product> GetByName(string filter)
        {
            return new DProduct().GetByName(filter);
        }


        public bool Register(Product product)
        {
            return new DProduct().Register(product);
        }


        public bool Update(Product product)
        {
            return new DProduct().Update(product);
        }


        public bool Delete(int productId)
        {
            return new DProduct().Delete(productId);
        }
    }
}
