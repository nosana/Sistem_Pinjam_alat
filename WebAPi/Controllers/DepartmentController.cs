using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;
using WebAPi.Repositories.Interface;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<DepartmentRepository, Department>
    {
        private DepartmentRepository _departmentRepository;
        MyContext myContext;

        public DepartmentController(DepartmentRepository repository, MyContext myContext) : base(repository)
        {
            _departmentRepository = repository;
            this.myContext = myContext;
        }
        /*[HttpGet("Name")]
        public IActionResult Get(string name)
        {
            var data = _departmentRepository.Get(name);
            return Ok(new
            {
                Message = "Data has been Retrieved",
                StatusCode = 200,
                data = data
            });

        }*/

        [HttpGet("DeptAppDev")]
        public ActionResult GetAppDev()
        {
            var departAppDev = from U in myContext.Users
                               join D in myContext.Departments on U.DepartmentId equals D.Id
                               where U.DepartmentId == 2
                               select new
                               {
                                   User = U.FullName,
                                   Department = D.Name
                               };
            return Ok(departAppDev);
           
        }
        [HttpGet("DeptHrd")]
        public ActionResult GetHrd()
        {
            var departHrd = from U in myContext.Users
                            join D in myContext.Departments on U.DepartmentId equals D.Id
                            where U.DepartmentId == 1
                             select new
                              {
                                 User = U.FullName,
                                  Department = D.Name
                               };
            return Ok (departHrd);
        }
        [HttpGet("DeptAdmin")]
        public ActionResult GetAdmin()
        {
            var departAdmin = from U in myContext.Users
                            join D in myContext.Departments on U.DepartmentId equals D.Id
                            where U.DepartmentId == 3
                            select new
                            {
                                User = U.FullName,
                                Department = D.Name
                            };
            return Ok(departAdmin);
        }
        [HttpGet("ManagementBusinessService ")]
        public ActionResult GetDeptMBS()
        {
            var mbs = from U in myContext.Users
                      join D in myContext.Departments on U.DepartmentId equals D.Id
                      where U.DepartmentId == 4
                      select new
                      {
                          User = U.FullName,
                          Department = D.Name
                      };
            return Ok(mbs);
        }

    }
}
