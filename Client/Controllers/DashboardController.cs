using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Client.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Dashboard/Employee")]
        public IActionResult Employee()
        {
            var token = HttpContext.Session.GetString("token");
            ViewData["token"] = token;

            var jwtReader = new JwtSecurityTokenHandler();
            var jwt = jwtReader.ReadJwtToken(token);
            var id = jwt.Claims.First(c => c.Type == "Id").Value;
            var fullName = jwt.Claims.First(c => c.Type == "FullName").Value;
            ViewData["id"] = id;
            ViewData["fullName"] = fullName;
            return View();
        }

        [Route("Dashboard/Manager")]
        public IActionResult Manager()
        {
            var token = HttpContext.Session.GetString("token");
            ViewData["token"] = token;

            var jwtReader = new JwtSecurityTokenHandler();
            var jwt = jwtReader.ReadJwtToken(token);
            var id = jwt.Claims.First(c => c.Type == "Id").Value;
            var fullName = jwt.Claims.First(c => c.Type == "FullName").Value;
            ViewData["id"] = id;
            ViewData["fullName"] = fullName;
            return View();
        }

        [Route("Dashboard/Admin")]
        public IActionResult Admin()
        {
            var token = HttpContext.Session.GetString("token");
            ViewData["token"] = token;

            var jwtReader = new JwtSecurityTokenHandler();
            var jwt = jwtReader.ReadJwtToken(token);
            var id = jwt.Claims.First(c => c.Type == "Id").Value;
            var fullName = jwt.Claims.First(c => c.Type == "FullName").Value;
            ViewData["id"] = id;
            ViewData["fullName"] = fullName;
            return View();
        }
    }
}
