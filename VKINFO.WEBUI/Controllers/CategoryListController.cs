using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VKINFO.APPLICATION.BookCategoryList.Queries.GetBookCategoryList;

namespace VKINFO.WEBUI.Controllers
{
    public class CategoryListController : BaseController
    {
        public async Task<IActionResult> Index(int id, int page)
        {
            var category = await Mediator.Send(new GetCategoryListQuery {Id = id, Page = page});
            if (category.Category == null)
            {
                return View("Error");
            }
            else
            {
                return View(category);
            }
        }

    }
}