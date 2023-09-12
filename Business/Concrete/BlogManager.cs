using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using CoreL.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _repoblog;

        public BlogManager(IBlogDal repoblog)
        {
            _repoblog = repoblog;
        }

        public IDataResult<List<Blog>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Blog>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Blog>>(_repoblog.GetAll(), Messages.BlogsListed);
            }
        }
        public IDataResult<List<Blog>> GetBlogById(int id)
        {
            return new SuccessDataResult<List<Blog>>(_repoblog.GetAll(x => x.BlogID == id));
        }

        public IDataResult<List<Blog>> GetBlogByCategory(int id)
        {
            return new SuccessDataResult<List<Blog>>(_repoblog.GetAll(x => x.CategoryID == id));
        }



        public IDataResult<Blog> GetById(int blogId)
        {
            return new SuccessDataResult<Blog>(_repoblog.Get(p => p.BlogID == blogId));
        }


        public IResult Add(Blog blog)
        {
             var context = new ValidationContext<Blog>(blog);
            BlogValidator blogalidationRules = new BlogValidator();
            var result = blogalidationRules.Validate(context);
            if(!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }

            _repoblog.AddAsync(blog);
            return new SuccessResult(Messages.BlogAdded);
        }
        public IResult DeleteBlogBL(int id)
        {
            Blog blog = _repoblog.Find(x => x.BlogID == id);
            _repoblog.DeleteAsync(blog);
            return new SuccessResult(Messages.BlogAdded);

        }
        public Blog FindBlog(int id)
        {
            return _repoblog.Find(x => x.BlogID == id);
        }
        public IResult UpdateBlog(Blog b)
        {
            Blog blog = _repoblog.Find(x => x.BlogID == b.BlogID);
            blog.BlogTitle = b.BlogTitle;
            blog.BlogContent = b.BlogContent;
            blog.BlogDate = b.BlogDate;
            blog.BlogImage = b.BlogImage;
            blog.CategoryID = b.CategoryID;
            _repoblog.UpdateAsync(blog);
            return new SuccessResult(Messages.CommentUpdate);

        }

        public IDataResult<List<Blog>> TopTreePost()
        {
            return new SuccessDataResult<List<Blog>>(_repoblog.GetAll().OrderByDescending(x => x.BlogRating).Take(3).ToList());
        }

        public IDataResult<List<Blog>> TopFivePost()
        {
            return new SuccessDataResult<List<Blog>>(_repoblog.GetAll().OrderByDescending(x => x.BlogRating).Take(5).ToList());
        }
    }
}
