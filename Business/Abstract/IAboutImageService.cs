using CoreL.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutImageService
    {
        IDataResult<List<AboutImage>> GetAll();
        IDataResult<AboutImage> GetById(int ImageId);
        IDataResult<List<AboutImage>> GetByAboutId(int AboutId);
        IResult Add(IFormFile file, AboutImage aboutImage);
        IResult Update(IFormFile file, AboutImage aboutImage);
        IResult Delete(AboutImage aboutImage);
    }
}
