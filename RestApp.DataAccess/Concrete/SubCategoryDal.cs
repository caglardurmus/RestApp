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
    public class SubCategoryDal : LiteDbRepository<SubCategory>, ISubCategoryDal
    {
        public void AddDefaultSubCategories()
        {
            var subCategories = new List<SubCategory>
            {
                new SubCategory
                {
                    Id= 1,
                    CategoryId = 1,
                    SubCategoryName = "Burgers"
                },
                new SubCategory
                {
                    Id= 2,
                    CategoryId = 1,
                    SubCategoryName = "Pizzas"
                },
                new SubCategory
                {
                    Id= 3,
                    CategoryId = 1,
                    SubCategoryName = "Breakfast"
                },
                new SubCategory
                {
                    Id= 4,
                    CategoryId = 2,
                    SubCategoryName = "Cold Drinks"
                },
                new SubCategory
                {
                    Id= 5,
                    CategoryId = 2,
                    SubCategoryName = "Hot Drinks"
                },
                new SubCategory
                {
                    Id= 6,
                    CategoryId = 3,
                    SubCategoryName = "Frozen Desserts"
                },
                new SubCategory
                {
                    Id= 7,
                    CategoryId = 3,
                    SubCategoryName = "Jellied Desserts"
                }
            };
            foreach (var item in subCategories)
            {
                this.collection.Insert(item);
            }
        }
    }
}
