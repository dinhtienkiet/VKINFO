using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VKINFO.APPLICATION.HomeAdmin.Queries.GetHomeAdmin;
using VKINFO.APPLICATION.Search.Queries.SearchAll;
using VKINFO.WEBADMIN.Models;

namespace VKINFO.WEBADMIN.Controllers
{
    [Authorize(Roles = "1,2")]
    public class HomeController : BaseController
    {
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var result = await Mediator.Send(new HomeAdminViewModelQuery ());
            return View(result);
        }
        public async Task<IActionResult> Search(string search)
        {
            var resul = await Mediator.Send(new SearchQuery { Text = search });
            return View(resul);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
      
    }
}
