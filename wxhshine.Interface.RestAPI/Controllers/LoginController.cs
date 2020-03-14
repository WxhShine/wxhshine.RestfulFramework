using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login()
        {
            string token = "12345";
            string loginUser = "hui";
            var identity = new ClaimsIdentity("Forms");

            identity.AddClaim(new Claim(ClaimTypes.Name, loginUser));
            identity.AddClaim(new Claim(ClaimTypes.Sid, token));

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return Ok("登陆成功");
        }

        [HttpGet("reLogin")]
        public IActionResult ReLogin([FromQuery] string returnUrl)
        {
            Console.WriteLine("重新登录");
            Login();
            return Redirect(returnUrl);
        }
    }
}
