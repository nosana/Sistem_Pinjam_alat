using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Context;
using WebAPi.Handlers;
using WebAPi.Models;
using WebAPi.ViewModel;

namespace WebAPi.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account>
    {
        private MyContext myContext;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        [HttpPost]
        public ResponseLoginVm Login(LoginVM loginVm)
        {
            ResponseLoginVm responseLogin = new ResponseLoginVm();
            var data = myContext.Users.Where(u => u.Email == loginVm.Email).SingleOrDefault();
            if (data == null)
            {
                return responseLogin;
            }
            else
            {
                var result = myContext.Accounts.Where(a => a.Id == data.Id).SingleOrDefault();
                if (result == null)
                {
                    return responseLogin;
                }
                else
                {
                    var validatePass = Hashing.ValidatePassword(loginVm.Password, result.Password);
                    if (validatePass)
                    {
                        var roles = myContext.AccountRoles
                        .Where(r => r.AccountId == result.Id).SingleOrDefault();

                        var rolename = myContext.Roles.Where(r => r.Id == roles.RoleId).SingleOrDefault();
                        responseLogin.Id = data.Id;
                        responseLogin.FullName = data.FullName;
                        responseLogin.Email = data.Email;
                        responseLogin.Roles = rolename.Name;

                        return responseLogin;
                    }
                }
            }
            return null;
        }

        public int ChangePassword(ChangePassVM changePassVM)
        {

            var data = myContext.Accounts
                .Include(x => x.User)
                .SingleOrDefault(x => x.User.Email.Equals(changePassVM.Email));
            if (data != null)
            {

                if (Hashing.ValidatePassword(changePassVM.OldPassword, data.Password))
                {
                    data.Password = Hashing.HashPassword(changePassVM.PasswordNew);
                    myContext.Entry(data).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    if (result > 0)
                    {
                        return result;
                    }
                    return 0;
                }
                return 0;
            }

            return 0;
        }

        public int ForgotPassword(ForgotPassVM forgotPassVm)
        {
            var data = myContext.Accounts
           .Where(a => a.User.Email.Equals(forgotPassVm.Email) && a.User.FullName.Equals(forgotPassVm.Fullname)).SingleOrDefault();

            if (data == null)
            {

                return 0;
            }
            else
            {
                data.Password = Hashing.HashPassword(forgotPassVm.PasswordNew);

                myContext.Entry(data).State = EntityState.Modified;

                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    return result;
                }
                return 0;
            }
            return 0;

            /*var data = myContext.Accounts
           .Include(x => x.User)

           .SingleOrDefault(x => x.User.Email.Equals(forgotPassVm.Email) && x.User.FullName.Equals(forgotPassVm.Fullname));

            if (data != null)
            {

                data.Password = Hashing.HashPassword(forgotPassVm.PasswordNew);

                myContext.Entry(data).State = EntityState.Modified;

                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    return result;
                }
                return 0;
            }
            return 0;*/
        }
    }

    
}
