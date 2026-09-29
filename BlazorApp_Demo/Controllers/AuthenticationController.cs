using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eShop.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        [Route("/authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery]string? user, [FromQuery]string? pwd)
        {
            if (!string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(pwd))
            {
                if (user == "admin" && pwd == "adminadmin")
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user),
                        new Claim(ClaimTypes.Email, "admin@eshop.com"),
                        new Claim(ClaimTypes.HomePhone, "12345678")
                    };

                    var userIdentity = new ClaimsIdentity(userClaims, "eShop.CookieAuth");
                    var userPrincipal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync("eShop.CookieAuth", userPrincipal);
                    return Redirect("/outstandingorders");
                }
                else
                {
                    return Redirect("/admin?error=invalid");
                }
            }

            return Redirect("/admin");
        }

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("eShop.CookieAuth");
            return Redirect("/admin");
        }
    }
}
