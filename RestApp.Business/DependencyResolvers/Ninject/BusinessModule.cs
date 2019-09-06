using Ninject.Modules;
using RestApp.DataAccess.Abstract;
using RestApp.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryDal>().To<CategoryDal>().InSingletonScope();
            Bind<IProductDal>().To<ProductDal>().InSingletonScope();
            Bind<ISubCategoryDal>().To<SubCategoryDal>().InSingletonScope();
        }
    }
}
