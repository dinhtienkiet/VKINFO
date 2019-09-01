using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.WEBUI.Controllers
{
    public class BaseController : Controller
    {
        private IMediator _mediator;
        /*private readonly IVKDbContext _context;*/

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        /*public void GetViewBag(int? ID = null)
        {
            var category = _context.Categories.ToList();
            ViewBag.CategoryID = new SelectList(category, "Id", "Name", ID);
        }*/
    }
}