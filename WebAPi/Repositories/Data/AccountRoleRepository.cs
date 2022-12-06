using WebAPi.Context;
using WebAPi.Models;

namespace WebAPi.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepository<AccountRole>
    {
        private MyContext myContext;
        public AccountRoleRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
