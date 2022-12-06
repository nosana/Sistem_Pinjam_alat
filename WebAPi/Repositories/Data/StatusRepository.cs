using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.ViewModel;

namespace WebAPi.Repositories.Data
{
    public class StatusRepository : GeneralRepository<Status>
    {
        private MyContext myContext;
        public StatusRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        [HttpPut]
        public int Approve(RequestItemVM requestItem)
        {
            var request = new RequestItem
            {
                Id = requestItem.Id,
                AccountId = requestItem.AccountId,
                ItemId = requestItem.ItemId,
                StartDate = requestItem.StartDate,
                EndDate = requestItem.EndDate,
                Quantity = requestItem.Quantity,
                Notes = requestItem.Notes,
                StatusId = 4 //Already Approved
            };
            myContext.Entry(request).State = EntityState.Modified;
            myContext.SaveChanges();

            return 0;
        }
    }
}
