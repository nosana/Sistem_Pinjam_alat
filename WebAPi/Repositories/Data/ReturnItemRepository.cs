using WebAPi.Context;
using WebAPi.Models;

namespace WebAPi.Repositories.Data
{
    public class ReturnItemRepository : GeneralRepository<ReturnItem>
    {
        private MyContext myContext;
        public ReturnItemRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
