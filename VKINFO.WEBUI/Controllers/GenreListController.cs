using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VKINFO.APPLICATION.GenreList.Queries.GetGenreList;

namespace VKINFO.WEBUI.Controllers
{
    public class GenreListController : BaseController
    {
        public async Task<IActionResult> Index(int id, int page)
        {
            var genre = await Mediator.Send(new GetGenreListQuery { Id = id, Page = page });
            if (genre.Genre == null)
            {
                return View("Error");
            }
            else
            {
                return View(genre);
            }
        }
    }
}