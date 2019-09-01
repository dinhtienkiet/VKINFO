using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VKINFO.APPLICATION.GenreAdmin.Commands.CreateGenre;
using VKINFO.APPLICATION.GenreAdmin.Commands.DeleteGenre;
using VKINFO.APPLICATION.GenreAdmin.Commands.EditGenre;
using VKINFO.APPLICATION.GenreAdmin.Queries.GetAllGenreAdmin;
using VKINFO.APPLICATION.GenreAdmin.Queries.GetGenreAdmin;
using VKINFO.APPLICATION.Search.Queries.SearchAll;

namespace VKINFO.WEBADMIN.Controllers
{
    [Authorize(Roles = "1")]
    public class GenreController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var Genre = await Mediator.Send(new GenreAdminQuery ());
            var List = new GenreAdminListViewModel
            {
                List = Genre
            };
            return View(List) ;
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var abc = await Mediator.Send(new DeleteGenreCommand { Id = id });
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id, int page)
        {
            var Genre = await Mediator.Send(new GetGenreAdminQuery { Id = id, Page = page});
            if(Genre == null)
            {
                return RedirectToAction("Error","Home");
            }
            else
            {
                return View(Genre);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditGenreCommand Genre)
        {
            await Mediator.Send(Genre);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateGenreCommand Genre)
        {
            await Mediator.Send(Genre);
            return RedirectToAction("Index");
        }

    }
}