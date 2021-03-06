﻿using Core.DataAccess;
using RestApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.DataAccess.Abstract
{
    public interface ISubCategoryDal : IRepositoryBase<SubCategory>
    {
        void AddDefaultSubCategories();
    }
}
