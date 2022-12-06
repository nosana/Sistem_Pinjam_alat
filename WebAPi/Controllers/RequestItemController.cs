using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;
using WebAPi.ViewModel;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestItemController : BaseController<RequestItemRepository, RequestItem>
    {
        private RequestItemRepository _requestItemRepository;
        private MyContext myContext;
        public RequestItemController(RequestItemRepository repository, MyContext myContext) : base(repository)
        {
            _requestItemRepository = repository;
           this.myContext = myContext;  
        }
        [HttpPost(("NewRequest"))]
        public ActionResult RequestItem(RequestItem requestItem)
        {
            try
            {
                var data = _requestItemRepository.RequestItem(requestItem);
                if (data > 0)
                {
                    //return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Request Item Gagal" });
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Request Item Berhasil",
                        Data = data
                    });
                }
                else
                {
                   
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Request Item Gagal"
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
    }
}
