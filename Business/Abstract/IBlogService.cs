using CoreL.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IDataResult<List<Blog>> GetAll();
        IDataResult<List<Blog>> GetBlogById(int id);
        IDataResult<List<Blog>> GetBlogByAuthor(int id);
        IDataResult<List<Blog>> GetBlogByCategory(int id);
        IResult DeleteBlogBL(int p);
        Blog FindBlog(int id);
        IResult UpdateBlog(Blog p);


        IDataResult<Blog> GetById(int blogId);
        IResult Add(Blog blog);
    }
}
