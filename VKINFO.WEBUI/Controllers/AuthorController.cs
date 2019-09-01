using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VKINFO.APPLICATION.AuthorUI.Queries.GetAuthorList;

namespace VKINFO.WEBUI.Controllers
{
    public class AuthorController : BaseController
    {
        public async Task<IActionResult> Index(int id, int page)
        {
            var author = await Mediator.Send(new GetAuthorListQuery { Id = id, CurrentPage = page });
            if (author.Author == null)
            {
                return View("Error");
            }
            else
            {
                return View(author);
            }
        }
    }
}
