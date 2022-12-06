using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnItemController : BaseController<ReturnItemRepository, ReturnItem>
    {
        private ReturnItemRepository _retutnItemRepository;
        private MyContext myContext;
        public ReturnItemController(ReturnItemRepository repository, MyContext myContext) : base(repository)
        {
            this.myContext = myContext;
            _retutnItemRepository = repository; 
        }
        [HttpPost("NewReturn")]
        public ActionResult ReturnItem(ReturnItem returnItem)
        {
            try
            {
                var rtrnItem = new ReturnItem
                {
                    RequestItemId = returnItem.RequestItemId,
                    Notes = returnItem.Notes
                };

                myContext.ReturnItems.Add(rtrnItem);
                var result = myContext.SaveChanges();
                if (result > 0)
                {


                    var dataRequest = myContext.RequestItems.Where(R => R.Id == returnItem.RequestItemId).FirstOrDefault();
                    var data = myContext.Items.Include(I => I.RequestItems).Where(I => I.Id == dataRequest.ItemId).FirstOrDefault();
                    data.Quantity += dataRequest.Quantity;
                    myContext.Entry(data).State = EntityState.Modified;
                    //myContext.SaveChanges();

                    dataRequest.StatusId = 2; // Returned
                    myContext.Entry(dataRequest).State = EntityState.Modified;

                    myContext.SaveChanges();
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Has Returned",
                        Data = data
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Data Hasn't Retruned"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
    }
}
