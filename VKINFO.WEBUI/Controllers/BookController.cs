using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VKINFO.APPLICATION.BooksUI.Queries.GetBook;

namespace VKINFO.WEBUI.Controllers
{
    public class BookController : BaseController
    {
        public async Task<IActionResult> Index(int id, int page)
        {
            var book = await Mediator.Send(new GetBookQuery { Id = id , CurrentPage = page});
            if (book.Book == null)
            {
                return View("Error");
            }
            else
            {
                return View(book);
            }
        }
        // GET: Books
    }
}
