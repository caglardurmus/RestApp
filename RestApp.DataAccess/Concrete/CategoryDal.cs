using Core.LiteDb;
using RestApp.DataAccess.Abstract;
using RestApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.DataAccess.Concrete
{
    public class CategoryDal : LiteDbRepository<Category>, ICategoryDal
    {
        public void AddDefaultCategories()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id= 1,
                    CategoryName = "Food"
                },
                new Category
                {
                    Id= 2,
                    CategoryName = "Drink"
                },
                new Category
                {
                    Id= 3,
                    CategoryName = "Dessert"
                }
            };
            foreach (var item in categories)
            {
                this.collection.Insert(item);
            }
        }
    }
}
