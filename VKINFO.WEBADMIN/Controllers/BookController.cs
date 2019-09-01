using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VKINFO.APPLICATION.Authors.Queries.GetAllAuthor;
using VKINFO.APPLICATION.BooksAdmin.Commands.CreateBookAdmin;
using VKINFO.APPLICATION.BooksAdmin.Commands.DeletBookAdmin;
using VKINFO.APPLICATION.BooksAdmin.Commands.UpdateBookAdmin;
using VKINFO.APPLICATION.BooksAdmin.Queries.getBookAdminById;
using VKINFO.APPLICATION.CategoryAdmin.Queries.GetAllCategoryAdmin;
using VKINFO.APPLICATION.ChapterAdmin.Command.CreateChapterAdmin;
using VKINFO.APPLICATION.ChapterAdmin.Command.DeleteChapterAdmin;
using VKINFO.APPLICATION.ChapterAdmin.Command.UpdateChapterAdmin;
using VKINFO.APPLICATION.ChapterAdmin.Queries.GetChapterById;
using VKINFO.APPLICATION.GenreAdmin.Queries.GetAllGenreAdmin;
using VKINFO.APPLICATION.GenreAdmin.Queries.GetGenreAdmin;
using VKINFO.APPLICATION.Queries.BooksAdmin.GetAllBookAdmin;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.WEBADMIN.Controllers
{
    [Authorize(Roles = "1")]
    public class BookController : BaseController
    {
        private string NonUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            text = text.ToLower();
            String [] line = text.Split(" ");
            string lineTest ="";
            foreach(String lineTx in line)
            {
                lineTest += lineTx +" ";
            }
            lineTest = lineTest.Trim();
            lineTest = lineTest.Replace(" ","-");
            return lineTest;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page)
        {
            var bookList = await Mediator.Send(new GetAllBookAdminQuery { CurrentPage = page});
            return View(bookList);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id,int page )
        {
            var book = await Mediator.Send(new GetBookAdminQuery { Id = Id,CurrentPage = page });
            var categoryList = await Mediator.Send(new CategoryAdminQueries());
            var authorList = await Mediator.Send(new AuthorQuery());
            var genreList = await Mediator.Send(new GenreAdminQuery());
            CreateBookAdminViewModel createBookAdminViewModel = new CreateBookAdminViewModel()
            {
                authorAdminViewModels = authorList,
                bookDto = book,
                categoryAdminViewModelList = categoryList,
                genreAdminViewModels = genreList
            };
            return View(createBookAdminViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile fileUpload, [FromForm]UpdateBookAdminCommand request)
        {
            if (fileUpload != null)
            {
                string imageBook = "/assets/images/book/";
                var savePath = $"../VKINFO.WEBADMIN/wwwroot{imageBook}";
                string[] fileTypes = { ".jpeg", ".jpg", ".png", ".gif" };
                string extFile = System.IO.Path.GetExtension(fileUpload.FileName);
                var bookById = await Mediator.Send(new GetBookAdminQuery { Id = request.Id });
                var oldImage = bookById.Image;
                if (oldImage != null)
                {
                    var image = Regex.Replace(oldImage, imageBook, String.Empty);
                    var oldpath = Path.Combine(Directory.GetCurrentDirectory(), savePath, image);
                    FileInfo fileInfo = new FileInfo(oldpath);
                    if (fileInfo.Exists)
                    {
                        fileInfo.Delete();
                    }
                }
                if (!((IList<string>)fileTypes).Contains(extFile.ToLower()))
                {
                    ModelState.AddModelError("errFileUpload", "Please upload file having extensions .jpeg/.jpg/.png/.gif only.");
                    return View();
                }
                string fileName = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".jpg";
                var path = Path.Combine(Directory.GetCurrentDirectory(), savePath, fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }              
                request.Image = imageBook + fileName;
                request.Slug = NonUnicode(request.Title);
                await Mediator.Send(request);
                return RedirectToAction("Index",new { Id = request.Id });
            }
            request.Slug = NonUnicode(request.Title);
            await Mediator.Send(request);
            return RedirectToAction("Edit", new { Id = request.Id });
        }
        [HttpGet]
        public async Task<IActionResult> CreateChapter(int Id)
        {
            var book = await Mediator.Send(new GetBookAdminQuery { Id = Id });
            if(book != null)
            {
                if (book.Status == 1)
                {
                    return RedirectToAction("Index");
                }
                var chapter = new Chapter
                {
                    BookId = Id
                };
                return View(chapter);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> CreateChapter(CreateChapterAdminCommand request)
        {
            await Mediator.Send(request);
            return RedirectToAction("Edit","Book",new { Id = request.BookId});
        }
        [HttpGet]
        public async Task<IActionResult> EditChapter(int Id)
        {
            var chapter = await Mediator.Send(new ChapterAdminViewModelQuery { Id = Id });
            if (chapter == null)
            {
                return RedirectToAction("Index");
            }
            return View(chapter);
        }
        [HttpPost]
        public async Task<IActionResult> EditChapter([FromForm] UpdateChapterAdminCommand request)
        {
            var chapter = await Mediator.Send(new UpdateChapterAdminCommand
            {
                Title = request.Title,
                Content = request.Content,
                Id = request.Id,
                Description = request.Description,
                Status = request.Status
            });
            if (chapter == null)
            {
                return View();
            }
            return RedirectToAction("Edit","Book",new { Id = request.BookId});
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var bookList = await Mediator.Send(new CategoryAdminQueries());
            var authorList = await Mediator.Send(new AuthorQuery());
            var genreList = await Mediator.Send(new GenreAdminQuery());
            CreateBookAdminViewModel createBookAdminViewModel = new CreateBookAdminViewModel()
            {
                categoryAdminViewModelList = bookList,
                authorAdminViewModels = authorList,
                genreAdminViewModels = genreList
            };
            return View(createBookAdminViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile fileUpload, [FromForm]CreateBookAdminCommand request)
        {
            if (fileUpload != null)
            {
                string imageBook = "/assets/images/book/";
                var savePath = $"../VKINFO.WEBADMIN/wwwroot{imageBook}";
                string[] fileTypes = { ".jpeg", ".jpg", ".png", ".gif" };
                string extFile = System.IO.Path.GetExtension(fileUpload.FileName);
                if (!((IList<string>)fileTypes).Contains(extFile.ToLower()))
                {
                    ModelState.AddModelError("errFileUpload", "Please upload file having extensions .jpeg/.jpg/.png/.gif only.");
                    return View();
                }
                string fileName = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".jpg";
                var path = Path.Combine(Directory.GetCurrentDirectory(), savePath, fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }
                request.Slug = NonUnicode(request.Title);
                request.Image = imageBook + fileName;
                await Mediator.Send(request);
                return RedirectToAction("Index");
            }
            request.Slug = NonUnicode(request.Title);
            request.Image = "https://images.pexels.com/photos/376718/pexels-photo-376718.jpeg?cs=srgb&dl=ch-tr-ng-tr-ng-tr-ng-tr-n-376718.jpg&fm=jpg";
            await Mediator.Send(request);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var book = await Mediator.Send(new DeleteBookAdminCommand { Id = Id });
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteChapter(int Id)
        {
            var book = await Mediator.Send(new DeleteChapterAdminCommand { Id = Id });
            return RedirectToAction("Index");
        }
       
    }
}