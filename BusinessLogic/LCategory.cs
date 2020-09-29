using System.Collections.Generic;
using Data;
using Entities;

namespace BusinessLogic
{
    public class LCategory
    {

        public List<Category> GetAll()
        {
            return new DCategory().GetAll();
        }

    }
}
