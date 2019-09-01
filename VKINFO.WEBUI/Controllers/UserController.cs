using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VKINFO.APPLICATION.Users.Queries.GetUser;

namespace VKINFO.WEBUI.Controllers
{
    public class UserController : BaseController
    {
        public async Task<IActionResult> Get(int id)
        {
            var user = await Mediator.Send(new GetUserQuery { Id = id });
            return View(user);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}