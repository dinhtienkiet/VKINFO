using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VKINFO.APPLICATION.Users.Commands.UpdateUser;
using VKINFO.APPLICATION.Users.Queries.GetUser;
using VKINFO.APPLICATION.Users.Queries.Login;

namespace VKINFO.WEBADMIN.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login( [FromForm] UserLoginQuery request)
        {
            var user = await Mediator.Send(new UserLoginQuery { Username = request.Username,Password = request.Password});
            if(user == null)
            {
                return RedirectToAction("Login");
            }
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role.ToString())                  
                };
            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
             userPrincipal, new AuthenticationProperties
             {
                 ExpiresUtc = DateTime.UtcNow.AddMinutes(90),
                 IsPersistent = false,
                 AllowRefresh = false
             }
              );
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "User");
        }       
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var Id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await Mediator.Send(new GetUserQuery { Id = Convert.ToInt32(Id)});
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] UpdateUserCommand request)
        {
            var user = await Mediator.Send(new UpdateUserCommand {
                Id = request.Id,
                Username = request.Username,
                Password = request.Password
            });
            if(user == null)
            {
                return RedirectToAction("Logout");
            }
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name,user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role.ToString())
                };
            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
             userPrincipal, new AuthenticationProperties
             {
                 ExpiresUtc = DateTime.UtcNow.AddMinutes(90),
                 IsPersistent = false,
                 AllowRefresh = false
             }
              );
            return RedirectToAction("Index", "Home");
        }

    }
}
