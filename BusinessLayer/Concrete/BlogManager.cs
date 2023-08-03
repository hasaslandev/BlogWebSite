using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager:IBlogService
    {
        IBlogDal _repoblog;

        public BlogManager(IBlogDal repoblog)
        {
            _repoblog = repoblog;
        }

        public List<Blog> GetAll()
        {
            return _repoblog.List();
        }
        public List<Blog> GetBlogById(int id)
        {
            return _repoblog.List(x => x.BlogID == id);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return _repoblog.List(x => x.AuthorID == id);
        }
        public List<Blog>GetBlogByCategory(int id)
        {
            return _repoblog.List(x=>x.CategoryID==id);
        }
        public int BlogAddBL(Blog p)
        {
            return _repoblog.Insert(p);
        }
        public int DeleteBlogBL(int p)
        {
            Blog blog = _repoblog.Find(x=>x.BlogID==p);
            return _repoblog.Delete(blog);
        }
        public Blog FindBlog(int id)
        {
            return _repoblog.Find(x=>x.BlogID==id);
        }
        public int UpdateBlog(Blog p)
        {
            Blog blog = _repoblog.Find(x => x.BlogID == p.BlogID);
            blog.BlogTitle = p.BlogTitle;
            blog.BlogContent = p.BlogContent;
            blog.BlogDate = p.BlogDate;
            blog.BlogImage = p.BlogImage;
            blog.CategoryID = p.CategoryID;
            blog.AuthorID = p.AuthorID;
            return _repoblog.Update(blog);
        }

    }
}
