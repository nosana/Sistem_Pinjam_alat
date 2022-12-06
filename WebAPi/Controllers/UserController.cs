using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;
using WebAPi.ViewModel;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<UserRepository, User>
    {
        private UserRepository _userRepository;
        private MyContext myContext;
        public UserController(UserRepository userRepository,MyContext myContext) : base(userRepository)
        {
            this._userRepository = userRepository;
            this.myContext = myContext;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(RegisterVM register)
        {
            try
            {
                var data = _userRepository.Register(register);
                if (data != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Kamu Berhasil Daftar"
                    });
                }
                return Ok(new
                {
                    StatusCode = 400,
                    Message = "Kamu Gagal Daftar",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }
    }
}
