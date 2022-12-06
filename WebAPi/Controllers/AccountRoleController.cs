using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using WebAPi.Base;
using WebAPi.Models;
using WebAPi.Repositories.Data;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountRoleController : BaseController<AccountRoleRepository,AccountRole>
    {
       private AccountRoleRepository _accountRoleRepository;

        public AccountRoleController(AccountRoleRepository repository) : base(repository)
        {
            _accountRoleRepository = repository;    
        }
    }
}
