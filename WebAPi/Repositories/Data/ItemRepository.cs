using WebAPi.Context;
using WebAPi.Models;

namespace WebAPi.Repositories.Data
{
    public class ItemRepository : GeneralRepository<Item>
    {
        private MyContext myContext;
        public ItemRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
