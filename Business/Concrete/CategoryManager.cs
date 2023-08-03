using Business.Abstract;
using Business.Constants;
using CoreL.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
           _categoryDal.AddAsync(category);
            return new SuccessResult(Messages.BlogAdded);
        }

        public IDataResult<List<Category>> GetAll()
        {
            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<Category>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.BlogsListed);
            }
        }
    }
}
