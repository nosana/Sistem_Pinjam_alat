using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.ViewModel;

namespace WebAPi.Repositories.Data
{
    public class RequestItemRepository : GeneralRepository<RequestItem>
    {
        private MyContext myContext;
        public RequestItemRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        [HttpPost]
        public int RequestItem(RequestItemVM requestItem)
        {
            var checkItem = myContext.Items.Where(i => i.Id == requestItem.ItemId).SingleOrDefault();
            if (requestItem.Quantity > checkItem.Quantity)
            {
                return 0;
            }
            else
            {
                var request = new RequestItem
                {
                    AccountId = requestItem.UserId,
                    ItemId = requestItem.ItemId,
                    StartDate = requestItem.StartDate,
                    EndDate = requestItem.EndDate,
                    Quantity = requestItem.Quantity,
                    Notes = requestItem.Notes,
                    StatusId = 3 //Waiting for Approval"
                };
                myContext.RequestItems.Add(request);
                myContext.SaveChanges();

                var data = myContext.Items.Include(a => a.RequestItems).Where(e => e.Id == request.ItemId).FirstOrDefault();
                data.Quantity -= requestItem.Quantity;
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result;

            }
            return 0;
        }
    }
}
