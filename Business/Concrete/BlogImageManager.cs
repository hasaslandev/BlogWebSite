using Business.Abstract;
using Business.Constants;
using CoreL.Utilities.Business;
using CoreL.Utilities.Helpers.FileHelper;
using CoreL.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogImageManager:IBlogImageService
    {
        IBlogImageDal _carImageDal;
        IFileHelper _fileHelperService;

        public BlogImageManager(IBlogImageDal carImageDal, IFileHelper fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;
        }


        public IResult Add(IFormFile file, BlogImage carImage)
        {
            IResult result = BusinessRules.Run(CheckForBlogImageLimit(carImage.BlogId));
            if (result != null)
            {
                return result;
            }

            carImage.BlogImageFolder = _fileHelperService.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;

            _carImageDal.AddAsync(carImage);
            return new SuccessResult(Messages.BlogAdded);

        }


        public IResult Delete(BlogImage carImage)
        {
            _fileHelperService.Delete(PathConstants.ImagesPath + carImage.BlogImageFolder);

            _carImageDal.DeleteAsync(carImage);
            return new SuccessResult(Messages.AboutDelete);
        }

        public IDataResult<List<BlogImage>> GetAll()
        {
            return new SuccessDataResult<List<BlogImage>>(_carImageDal.GetAll(), Messages.BlogsListed);
        }

        public IDataResult<BlogImage> GetById(int ImageId)
        {

            return new SuccessDataResult<BlogImage>(_carImageDal.Get(i => i.Id == ImageId), Messages.BlogsListed);
        }

        public IDataResult<List<BlogImage>> GetByCarId(int CarId)
        {
            IResult result = BusinessRules.Run(CheckImageExists(CarId));
            if (result != null)
            {
                return new ErrorDataResult<List<BlogImage>>(GetDefaultImage(CarId).Data);
            }

            return new SuccessDataResult<List<BlogImage>>(_carImageDal.GetAll(c => c.BlogId == CarId), Messages.BlogsListed);
        }

        public IResult Update(IFormFile file, BlogImage carImage)
        {

            carImage.BlogImageFolder = _fileHelperService.Update(file, PathConstants.ImagesPath + carImage.BlogImageFolder, PathConstants.ImagesPath);

            carImage.Date = DateTime.Now;

            _carImageDal.UpdateAsync(carImage);

            return new SuccessResult(Messages.ContactUpdate);
        }

        private IResult CheckForBlogImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(i => i.BlogId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.BlogsListed);
            }
            return new SuccessResult();
        }

        private IResult CheckImageExists(int carId)
        {
            var result = _carImageDal.GetAll(i => i.BlogId == carId).Count;

            if (result > 0)
            {
                return new ErrorResult(Messages.BlogLimitExceded);
            }
            return new SuccessResult();

        }

        private IDataResult<List<BlogImage>> GetDefaultImage(int carId)
        {

            List<BlogImage> carImages = new List<BlogImage>();

            carImages.Add(new BlogImage { BlogId = carId, Date = DateTime.Now, BlogImageFolder = "Logo.jpg" });

            return new SuccessDataResult<List<BlogImage>>(carImages);
        }
    }
}
