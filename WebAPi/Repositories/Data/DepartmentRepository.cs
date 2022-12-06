using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.ViewModel;

namespace WebAPi.Repositories.Data
{
    public class DepartmentRepository:GeneralRepository<Department>
    {
        private MyContext myContext;
        public DepartmentRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public int GetAppDev()
        {
            var departAppDev = from U in myContext.Users
                               join D in myContext.Departments on U.DepartmentId equals D.Id
                               where U.DepartmentId == 2
                               select new
                               {
                                   User = U.FullName,
                                   Department = D.Name
                               };
            if (departAppDev != null)
            {
                return 0;
            }
            return 1;
        }



    }
}
