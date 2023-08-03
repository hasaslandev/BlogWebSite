using CoreL.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> CommentList();

        IDataResult<List<Comment>> CommentById(int id);

        IDataResult<List<Comment>> CommentByStatusTrue();

        IDataResult<List<Comment>> CommentByStatusFalse();

        IResult CommentAdd(Comment c);

        //IResult CommentStatusChangeToFalse(int id);

        //IResult CommentStatusChangeToTrue(int id);
    }
}
