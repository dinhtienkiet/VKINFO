using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VKINFO.APPLICATION.CategoryAdmin.Commands.CreateCategory;
using VKINFO.APPLICATION.CategoryAdmin.Commands.DeleteCategory;
using VKINFO.APPLICATION.CategoryAdmin.Commands.UpdateCategory;
using VKINFO.APPLICATION.CategoryAdmin.Queries.GetAllCategoryAdmin;
using VKINFO.APPLICATION.CategoryAdmin.Queries.GetCategoryAdminByID;

namespace VKINFO.WEBADMIN.Controllers
{
    [Authorize(Roles = "1")]   
    public class CategoryController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var book = await Mediator.Send(new CategoryAdminQueries());
            return View(book);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var categoryAdmin = await Mediator.Send(new DeleteCategoryAdminCommand { Id = Id });
            if(categoryAdmin == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id, int page)
        {
            var categoryAdmin = await Mediator.Send(new CategoryAdminByIdQueries { Id = Id, CurrentPage = page});
            if(categoryAdmin == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(categoryAdmin);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] UpdateCategoryAdminCommand request)
        {
            var categoryAdmin = await Mediator.Send(request);
            if (categoryAdmin == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryAdminCommand request)
        {
            await Mediator.Send(request);
            return RedirectToAction("Index");
        }
    }
}