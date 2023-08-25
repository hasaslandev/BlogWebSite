using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using CoreL.Aspects.Autofac.Caching;
using CoreL.Aspects.Autofac.Performance;
using CoreL.Aspects.Autofac.Transaction;
using CoreL.Aspects.Autofac.Validation;
using CoreL.CrossCuttingConcerns.Validation;
using CoreL.Utilities.Business;
using CoreL.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;
        ICategoryService _categoryService;//******1 EntityManager kendisi haric başka dalı enjecte edemez*****
        public AboutManager(IAboutDal aboutDal, ICategoryService categoryService)
        {
            _aboutDal = aboutDal;
            _categoryService = categoryService;
        }
        //[CasheAspect]Key(Cashe verdiğimiz isim),Value
        [SecuredOperation("admin,product.add")]
        //[ValidationAspect(typeof(AboutValidator))]
        //[CacheRemoveAspect("IAboutsService.Get")]
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

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(About about)
        {
            Add(about);
            if(about.AboutContent1.Length<10)
            {
                throw new Exception("");
            }
            Add(about);
            return null;
        }

        public IResult Delete(int id)
        {
            About about = _aboutDal.Find(x => x.AboutID == id);
            if (about == null)
            {
                return new ErrorResult("about yok");
            }

            _aboutDal.DeleteAsync(about).Wait(); // await kullanılmış hali
            return new SuccessResult(Messages.AboutDelete);

        }

        [CacheAspect]//Key(Cashe verdiğimiz isim),Value
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
        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<About> GetById(int aboutId)
        {
            return new SuccessDataResult<About>(_aboutDal.Get(p => p.AboutID == aboutId));
        }
        [CacheRemoveAspect("IAboutsService.Get")]
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
