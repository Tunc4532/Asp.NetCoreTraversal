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
    public class AppRoleManager : IRoleService
    {
        IRoleDalr _roleDalr;

        public AppRoleManager(IRoleDalr roleDalr)
        {
            _roleDalr = roleDalr;
        }

        public AppRole GetByID(int id)
        {
            return _roleDalr.GetByID(id);
        }

        public void TAdd(AppRole t)
        {
           _roleDalr.Insert(t);
        }

        public void TDelete(AppRole t)
        {
            _roleDalr.Delete(t);
        }

        public List<AppRole> TGetList(AppRole t)
        {
            return _roleDalr.GetList();
        }

        public void TUpdate(AppRole t)
        {
           _roleDalr.Update(t);
        }
    }
}
