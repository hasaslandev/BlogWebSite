using Business.Abstract;
using Business.Constants;
using CoreL.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IDataResult<List<Comment>> CommentList()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(), Messages.BlogsListed);

        }
        public IDataResult<List<Comment>> CommentById(int id)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(x => x.CommentID == id));
        }
        public IDataResult<List<Comment>> CommentByStatusTrue()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(x => x.CommentStatus == true));
        }
        public IDataResult<List<Comment>> CommentByStatusFalse()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(x => x.CommentStatus == false));
        }
        public IResult CommentAdd(Comment c)
        {
            _commentDal.AddAsync(c);
            return new SuccessResult(Messages.BlogAdded);

        }
        //public IResult CommentStatusChangeToFalse(int id)
        //{
        //    return new SuccessDataResult<List<Comment>>(_commentDal.ListAll(x => x.CommentID == id));

        //    Comment comment = _commentDal.Find(x => x.CommentID == id);
        //    comment.CommentStatus = false;
        //    _commentDal.Update(comment);
        //}
        //public IResult CommentStatusChangeToTrue(int id)
        //{
        //    Comment comment = _commentDal.Find(x => x.CommentID == id);
        //    comment.CommentStatus = true;
        //    _commentDal.Update(comment);
        //}
    }
}
