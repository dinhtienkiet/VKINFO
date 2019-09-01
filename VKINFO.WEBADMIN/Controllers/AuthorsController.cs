using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Authors.Commands.CreateAuthor;
using VKINFO.APPLICATION.Authors.Commands.DeleteAuthor;
using VKINFO.APPLICATION.Authors.Commands.EditAuthor;
using VKINFO.APPLICATION.Authors.Queries.GetAllAuthor;
using VKINFO.APPLICATION.Authors.Queries.GetAuthor;
using VKINFO.DOMAIN.Entities;
using VKINFO.PERSISTENCE;

namespace VKINFO.WEBADMIN.Controllers
{
    [Authorize(Roles = "1")]
    public class AuthorsController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var ListAuthor = await Mediator.Send(new AuthorQuery());
            AuthorListModel authorListModel = new AuthorListModel
            {
                ListAuthor = ListAuthor
            };
            return View(authorListModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
             var Author = await Mediator.Send (new DeleteAuthorCommand{ Id = id });
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id, int Page)
        {
            var Author = await Mediator.Send(new GetAuthorQuery { Id = id, Page = Page});
            if (Author == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                return View(Author);
            }

            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditAuthorCommand Author)
        {
            await Mediator.Send(Author);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorCommand Author)
        {
            await Mediator.Send(Author);
            return RedirectToAction("Index");
        }

    }
}
