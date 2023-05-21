using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService
	{
		List<Comment> CommentList();

		List<Comment> CommentById(int id);

		List<Comment> CommentByStatusTrue();

		List<Comment> CommentByStatusFalse();

		int CommentAdd(Comment c);

		int CommentStatusChangeToFalse(int id);

		int CommentStatusChangeToTrue(int id);

	}
}
