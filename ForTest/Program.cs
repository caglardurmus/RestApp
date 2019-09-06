using RestApp.Business.DependencyResolvers.Ninject;
using RestApp.DataAccess.Abstract;
using RestApp.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = InstanceFactory.GetInstance<ICategoryDal>();
            //repo.AddDefaultCategories();


            var category = repo.GetById(1);

            Console.WriteLine(category.CategoryName + " " + category.Id);
            Console.ReadKey();

        }
    }
}
