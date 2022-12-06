using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;
using WebAPi.ViewModel;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : BaseController<StatusRepository, Status>
    {
        private StatusRepository _statusRepository;
        private MyContext myContext;
        public StatusController(StatusRepository repository, MyContext myContext) : base(repository)
        {
            _statusRepository = repository;
            this.myContext = myContext;
        }
        [HttpPut("Approve")]
        public ActionResult Approve(RequestItemVM requestItem)
        {
            try
            {
                var data = _statusRepository.Approve(requestItem);
                if (data > 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Approved",
                        Data = data
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Data Not Approve"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("ReqReject")]
        public ActionResult ReqReject()
        {
            var reqReject = from R in myContext.RequestItems
                            join S in myContext.Statuses on R.StatusId equals S.Id
                            where R.StatusId == 1
                            select new
                            {
                                Status = S.Name
                            };
            return Ok(reqReject);
        }

        [HttpGet("ReqReturn")]
        public ActionResult ReqReturn()
        {
            var reqReturn = from R in myContext.RequestItems
                            join S in myContext.Statuses on R.StatusId equals S.Id
                            where R.StatusId == 2
                            select new
                            {
                                Status = S.Name
                            };
            return Ok(reqReturn);
        }

        [HttpGet("ReqWaiting")]
        public ActionResult ReqWaiting()
        {
            var reqWaiting = from R in myContext.RequestItems
                             join S in myContext.Statuses on R.StatusId equals S.Id
                             where R.StatusId == 3
                             select new
                             {
                                 Status = S.Name
                             };
            return Ok(reqWaiting);
        }

        [HttpGet("ReqApprove")]
        public ActionResult ReqApprove()
        {
            var reqApprove = from R in myContext.RequestItems
                             join S in myContext.Statuses on R.StatusId equals S.Id
                             where R.StatusId == 4
                             select new
                             {
                                 Status = S.Name
                             };
            return Ok(reqApprove);
        }
    }
}
