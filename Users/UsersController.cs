using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Lucilvio.TicketMe.AnemicModel.Users
{
    public class UsersController : Controller
    {
        private readonly IUserSignInService _userSignInService;

        public UsersController(IUserSignInService userSignInService)
        {
            this._userSignInService = userSignInService;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromForm]string login, string password)
        {
            var issuer = "http://localhost:5000";

            var client = this._userSignInService.SignIn(login, password);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, client.Name, issuer),
                new Claim(ClaimTypes.NameIdentifier, client.Id.ToString(), issuer)
            };

            var userIdentity = new ClaimsIdentity(claims, "login");

            var claimsPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
            {
                IsPersistent = true,
                AllowRefresh = true,
                ExpiresUtc = DateTime.UtcNow.AddYears(10)
            });

            return RedirectToAction("Tickets", "Tickets");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return base.RedirectToAction("Tickets", "Tickets");
        }
    }
}   
