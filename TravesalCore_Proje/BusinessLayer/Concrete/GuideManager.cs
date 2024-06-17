using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GuideManager : IGuideService
    {
        IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public Guide GetByID(int id)
        {
            return _guideDal.GetByID(id);
        }

        public void TAdd(Guide t)
        {
            _guideDal.Insert(t);
        }

        public void TChamgeToFalseByGuide(int id)
        {
            _guideDal.ChamgeToFalseByGuide(id);
        }

        public void TChamgeToTrueByGuide(int id)
        {
            _guideDal.ChamgeToTrueByGuide(id);
        }

        public void TDelete(Guide t)
        {
           _guideDal.Delete(t);
        }

        public List<Guide> TGetList(Guide t)
        {
            return _guideDal.GetList();
        }

        public List<Guide>? TGetList()
        {
            return _guideDal.GetList();
        }

        public void TUpdate(Guide t)
        {
            _guideDal.Update(t);
        }

		object IGuideService.TGetList()
		{
			return _guideDal.GetList();
		}
	}
}
