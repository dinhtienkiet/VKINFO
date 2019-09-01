using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VKINFO.APPLICATION.ChapterUI.Queries.GetChapter;

namespace VKINFO.WEBUI.Controllers
{
    public class ChapterController : BaseController
    {
        public async Task<IActionResult> Index(int id)
        {
            var chapter = await Mediator.Send(new GetChapterQuery { Id = id });
            if (chapter == null)
            {
                return View("Error");
            }
            else
            {
                return View(chapter);
            }
        }
        // GET: Chapter
    }
}
