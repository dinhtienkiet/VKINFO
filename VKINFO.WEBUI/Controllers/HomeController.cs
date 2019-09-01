using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VKINFO.APPLICATION.HomeUI.Queries.Home;
using VKINFO.APPLICATION.SearchUI.Queries.Search;
using VKINFO.WEBUI.Models;


namespace VKINFO.WEBUI.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<IActionResult> Index(int page)
        {
            var home = await Mediator.Send(new HomeQuery { Page = page });
            return View(home);
        }
        public async Task<IActionResult> Search(string search)
        {
            var result = await Mediator.Send(new SearchQuery { Text = search });
            return View(result);
        }
    }
}
