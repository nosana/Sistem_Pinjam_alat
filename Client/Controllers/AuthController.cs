using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebAPi.ViewModel;

namespace Client.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public string Login(LoginVM loginVm)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(loginVm), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:7095/api/Accounts/Login", content).Result;


            var token = result.Content.ReadAsStringAsync().Result;
            HttpContext.Session.SetString("token", token);

            if (result.IsSuccessStatusCode)
            {
                var jwtReader = new JwtSecurityTokenHandler();
                var jwt = jwtReader.ReadJwtToken(token);
                var id = jwt.Claims.First(c => c.Type == "Id").Value;
                HttpContext.Session.SetString("id", id);
                ViewData["id"] = HttpContext.Session.GetString("id");
                var fullName = jwt.Claims.First(c => c.Type == "FullName").Value;
                HttpContext.Session.SetString("fullName", fullName);
                ViewData["fullName"] = HttpContext.Session.GetString("fullName");
                var role = jwt.Claims.First(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
                if (role == "Manager")
                {
                    return Url.Action("Manager", "Dashboard");
                }
                else if (role == "Admin")
                {
                    return Url.Action("Admin", "Dashboard");
                }
                else if (role == "Employee")
                {
                    return Url.Action("Employee", "Dashboard");
                }
                else
                {
                    return Url.Action("Index", "Home");
                }
            }
            else
            {
                return Url.Action("Error", "Home");
            }
        }

        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
