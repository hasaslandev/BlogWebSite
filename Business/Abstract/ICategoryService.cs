﻿using CoreL.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(int categoryId);
        IDataResult <Category> GetById(int id);

    }
}
