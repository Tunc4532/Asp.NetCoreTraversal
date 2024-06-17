﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public Comment GetByID(int id)
        {
            return _commentDal.GetByID(id);
        }

        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public List<Comment> TGetList(Comment t)
        {
            return _commentDal.GetList();
        }

        public List<Comment> TGetDestinationByID(int id)
        {
            return _commentDal.GetListByFilter(x=>x.DestinationID == id);   
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }

        public object TGetList()
        {
            return _commentDal.GetList();
        }

        public List<Comment> GetListCommentWithDestination()
        {
            return _commentDal.GetListCommentWithDestination();
        }
    }
}
