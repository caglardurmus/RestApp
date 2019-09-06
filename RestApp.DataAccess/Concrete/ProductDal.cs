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
    public class ProductDal : LiteDbRepository<Product>, IProductDal
    {
        public void AddDefaultProduts()
        {
            var products = new List<Product> {
                new Product
                {
                    Id=1,
                    SubCategoryId = 1,
                    ProductName = "Beef Burgers",
                    Price = 15,
                    Stock = 100
                },
                new Product
                {
                    Id=2,
                    SubCategoryId = 1,
                    ProductName = "Elk Burgers",
                    Price = 15,
                    Stock = 100
                },
                new Product
                {
                    Id=3,
                    SubCategoryId = 1,
                    ProductName = "Chicken Burgers",
                    Price = 15,
                    Stock = 100
                },
                new Product
                {
                    Id=4,
                    SubCategoryId = 2,
                    ProductName = "Neapolitan Pizza",
                    Price = 12,
                    Stock = 200
                },
                new Product
                {
                    Id=5,
                    SubCategoryId = 2,
                    ProductName = "Detroit Pizza",
                    Price = 15,
                    Stock = 100
                },
                new Product
                {
                    Id=6,
                    SubCategoryId = 2,
                    ProductName = "Margarita Pizza",
                    Price = 11,
                    Stock = 100
                },
                new Product
                {
                    Id=7,
                    SubCategoryId = 3,
                    ProductName = "Omelette",
                    Price = 10,
                    Stock = 20
                },
                new Product
                {
                    Id=8,
                    SubCategoryId = 3,
                    ProductName = "Toast",
                    Price = 8,
                    Stock = 100
                },
                new Product
                {
                    Id=9,
                    SubCategoryId = 4,
                    ProductName = "Cola",
                    Price = 4,
                    Stock = 500
                },
                new Product
                {
                    Id=10,
                    SubCategoryId = 4,
                    ProductName = "Sprite",
                    Price = 4,
                    Stock = 500
                },
                new Product
                {
                    Id=11,
                    SubCategoryId = 4,
                    ProductName = "Ice Tea",
                    Price = 4,
                    Stock = 500
                },
                new Product
                {
                    Id=12,
                    SubCategoryId = 5,
                    ProductName = "Tea",
                    Price = 2,
                    Stock = 500
                },
                new Product
                {
                    Id=13,
                    SubCategoryId = 5,
                    ProductName = "Coffee",
                    Price = 2,
                    Stock = 500
                },
                new Product
                {
                    Id=14,
                    SubCategoryId = 6,
                    ProductName = "Orange-Marshmallow",
                    Price = 20,
                    Stock = 500
                },
                new Product
                {
                    Id=15,
                    SubCategoryId = 6,
                    ProductName = "Strawberry Cheesecake",
                    Price = 26,
                    Stock = 500
                },
                new Product
                {
                    Id=16,
                    SubCategoryId = 7,
                    ProductName = "Matcha Jelly",
                    Price = 20,
                    Stock = 500
                }
            };
            foreach (var item in products)
            {
                this.collection.Insert(item);
            }
        }
    }
}