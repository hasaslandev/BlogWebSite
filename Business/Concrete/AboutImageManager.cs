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
    public class AboutImageManager : IAboutImageService
    {
        IAboutImageDal _aboutImageDal;
        IFileHelper _fileHelperService;

        public AboutImageManager(IAboutImageDal aboutImageDal, IFileHelper fileHelperService)
        {
            _aboutImageDal = aboutImageDal;
            _fileHelperService = fileHelperService;
        }
        public IResult Add(IFormFile file, AboutImage aboutImage)
        {
            aboutImage.AboutImageFolder = _fileHelperService.Upload(file, PathConstants.ImagesPath);
            aboutImage.Date = DateTime.Now;
            aboutImage.AboutId = 2;
            _aboutImageDal.AddAsync(aboutImage);
            return new SuccessResult(Messages.BlogAdded);
        }

        public IResult Delete(AboutImage aboutImage)
        {
            _fileHelperService.Delete(PathConstants.ImagesPath + aboutImage.AboutImageFolder);
            _aboutImageDal.DeleteAsync(aboutImage);
            return new SuccessResult(Messages.AboutDelete);
        }

        public IDataResult<List<AboutImage>> GetAll()
        {
            return new SuccessDataResult<List<AboutImage>>(_aboutImageDal.GetAll(), Messages.BlogsListed);
        }

        public IDataResult<AboutImage> GetById(int ImageId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, AboutImage aboutImage)
        {
            aboutImage.AboutImageFolder = _fileHelperService.Update(file, PathConstants.ImagesPath + aboutImage.AboutImageFolder, PathConstants.ImagesPath);

            aboutImage.Date = DateTime.Now;

            _aboutImageDal.UpdateAsync(aboutImage);

            return new SuccessResult(Messages.ContactUpdate);
        }
        public IDataResult<List<AboutImage>> GetByAboutId(int AboutId)
        {
            IResult result = BusinessRules.Run(CheckImageExists(AboutId));
            if (result != null)
            {
                return new ErrorDataResult<List<AboutImage>>(GetDefaultImage(AboutId).Data);
            }

            return new SuccessDataResult<List<AboutImage>>(_aboutImageDal.GetAll(c => c.AboutId == AboutId), Messages.BlogsListed);
        }
        private IResult CheckImageExists(int aboutId)
        {
            var result = _aboutImageDal.GetAll(i => i.AboutId == aboutId).Count;

            if (result > 0)
            {
                return new ErrorResult(Messages.BlogLimitExceded);
            }
            return new SuccessResult();

        }

        private IDataResult<List<AboutImage>> GetDefaultImage(int aboutId)
        {

            List<AboutImage> aboutImages = new List<AboutImage>();

            aboutImages.Add(new AboutImage { AboutId = aboutId, Date = DateTime.Now, AboutImageFolder = "Logo.jpg" });

            return new SuccessDataResult<List<AboutImage>>(aboutImages);
        }
    }
}
