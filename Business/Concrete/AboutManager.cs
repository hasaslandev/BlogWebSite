using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using CoreL.Aspects.Autofac.Validation;
using CoreL.CrossCuttingConcerns.Validation;
using CoreL.Utilities.Business;
using CoreL.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;
        ICategoryService _categoryService;
        public AboutManager(IAboutDal aboutDal, ICategoryService categoryService)
        {
            _aboutDal = aboutDal;
            _categoryService = categoryService;
        }
        [ValidationAspect(typeof(AboutValidator))]
        public IResult Add(About about)
        {
            //Metodun yukarsındaki ifade atribue demek ve bu metot çalışmadan önce yapılacak demek
            IResult result = BusinessRules.Run(
                CheckIfAboutNameExists(about.AboutContent1),
                CheckIfAboutCountBlogCorrent(about.AboutID),
                CheckIfBlogLimitExceded());

            if(result!=null) 
            {
                return result;
            }
            _aboutDal.AddAsync(about);
            return new SuccessResult(Messages.BlogAdded);
        }

        public IDataResult<List<About>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<About>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<About>>(_aboutDal.GetAll(), Messages.BlogsListed);
            }
        }

        [ValidationAspect(typeof(AboutValidator))]
        public IResult Update(About about)
        {

            _aboutDal.UpdateAsync(about);
            return new SuccessResult(Messages.BlogAdded);
        }
        private IResult CheckIfAboutCountBlogCorrent(int blogId)
        {
            var result = _aboutDal.GetAll(p => p.AboutID == blogId).Count;
            if (result >= 100)
            {
                return new ErrorResult(Messages.AboutCountOfBlogError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfAboutNameExists(string aboutName)
        {
            var result = _aboutDal.GetAll(p => p.AboutContent1 == aboutName).Any();
            if (result)
            {
                return new ErrorResult(Messages.AboutNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfBlogLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count<1)
            {
                return new ErrorResult(Messages.BlogLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
