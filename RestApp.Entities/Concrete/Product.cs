using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}
