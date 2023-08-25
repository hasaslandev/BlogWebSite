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
    public interface IBlogImageService
    {
        IDataResult<List<BlogImage>> GetAll();
        IDataResult<BlogImage> GetById(int ImageId);
        IDataResult<List<BlogImage>> GetByCarId(int CarId);
        IResult Add(IFormFile file, BlogImage carImage);
        IResult Update(IFormFile file, BlogImage carImage);
        IResult Delete(BlogImage carImage);
    }
}
