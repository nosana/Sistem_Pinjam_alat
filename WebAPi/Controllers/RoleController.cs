using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Models;
using WebAPi.Repositories.Data;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController<RoleRepository, Role>
    {
        private RoleRepository _roleRepository;
        public RoleController(RoleRepository repository) : base(repository)
        {
            _roleRepository = repository;
        }
    }
}
