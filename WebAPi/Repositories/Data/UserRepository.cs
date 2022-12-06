using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WebAPi.Context;
using WebAPi.Handlers;
using WebAPi.Models;
using WebAPi.ViewModel;

namespace WebAPi.Repositories.Data
{
    public class UserRepository : GeneralRepository<User>
    {
        private MyContext myContext;
        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        [HttpPost]
        public int Register(RegisterVM registerVM)
        {
            var id = myContext.Users.SingleOrDefault(x => x.Id.Equals(registerVM.Id));
            var data = myContext.Users.SingleOrDefault(x => x.Email.Equals(registerVM.Email));
            int result = 0;
            if (id == null && data == null)
            {
                User user = new User()
                {
                    Id = registerVM.Id,
                    FullName = registerVM.FullName,
                    Gender = registerVM.Gender,
                    BirthDate = registerVM.BirthDate,
                    Address = registerVM.Address,
                    Phone = registerVM.Phone,
                    Email = registerVM.Email,
                    DepartmentId = registerVM.DepartmentId
                };
                myContext.Users.Add(user);
                //myContext.SaveChanges();

                var accounts = new Account()
                {
                    Id = registerVM.Id,
                    Password = Hashing.HashPassword(registerVM.Password)
                };
                myContext.Accounts.Add(accounts);
                //myContext.SaveChanges();

                var accountRoles = new AccountRole()
                {
                    AccountId = registerVM.Id,
                    RoleId = registerVM.RoleId
                };
                myContext.AccountRoles.Add(accountRoles);
                result = myContext.SaveChanges();
            }

            return result;

            /*User user = new User()
            {
                FullName = register.FullName,
                Gender = register.Gender,
                BirthDate = register.BirthDate,
                Address = register.Address,
                Phone = register.Phone,
                Email = register.Email,
                DepartmentId = register.DepartmentId
            };
            myContext.Users.Add(user);
            var data = myContext.Users.SingleOrDefault(x => x.Email.Equals(register.Email));
            if (data == null)
            {
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    var id = myContext.Users.SingleOrDefault(x => x.Email.Equals(register.Email)).Id;


                    Account accounts = new Account()
                    {

                        Id = id,
                        Password = Hashing.HashPassword(register.Password),


                    };
                    myContext.Accounts.Add(accounts);
                    var resultUser = myContext.SaveChanges();
                }
                return result;
            }
            return 0;*/



        }
    }
}
