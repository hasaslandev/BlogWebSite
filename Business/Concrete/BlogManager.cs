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
        public IDataResult<List<Blog>> GetBlogByAuthor(int id)
        {
            return new SuccessDataResult<List<Blog>> (_repoblog.GetAll(x => x.AuthorID == id));
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
        public IResult DeleteBlogBL(int p)
        {
            Blog blog = _repoblog.Find(x => x.BlogID == p);
            _repoblog.DeleteAsync(blog);
            return new SuccessResult(Messages.BlogAdded);

        }
        public Blog FindBlog(int id)
        {
            return _repoblog.Find(x => x.BlogID == id);
        }
        public IResult UpdateBlog(Blog p)
        {
            Blog blog = _repoblog.Find(x => x.BlogID == p.BlogID);
            blog.BlogTitle = p.BlogTitle;
            blog.BlogContent = p.BlogContent;
            blog.BlogDate = p.BlogDate;
            blog.BlogImage = p.BlogImage;
            blog.CategoryID = p.CategoryID;
            blog.AuthorID = p.AuthorID;
            _repoblog.UpdateAsync(blog);
            return new SuccessResult(Messages.BlogAdded);

        }
    }
}
