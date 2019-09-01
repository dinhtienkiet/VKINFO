using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.BooksAdmin.Commands.UpdateBookAdmin;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.BooksAdmin.Queries.getBookAdminById
{
    public class getBookAdminQueryByIdHandler : IRequestHandler<GetBookAdminQuery, BookAminViewModelById>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public getBookAdminQueryByIdHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BookAminViewModelById> Handle(GetBookAdminQuery request, CancellationToken cancellationToken)
        {
            var Const = 10;
            var bookAdmin = _mapper.Map<BookAminViewModelById>
                (await _context.Books.Include(u => u.Author).
                Include(u => u.BookGenres).ThenInclude(x => x.Genre).Include(u => u.BookCategories).ThenInclude(x => x.Category)
                .Include(u => u.Chapters).SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken));
            if (bookAdmin == null)
            {
                return null;
            }
            bookAdmin.CurrentChapterPage = request.CurrentPage;
            int totalChapter = bookAdmin.chapterAdminByIdBookViewModels.Count();
            if (totalChapter % Const > 0)
            {
                bookAdmin.TotalChapterPage = (int)totalChapter / Const + 1;
            }
            else
            {
                bookAdmin.TotalChapterPage = (int)totalChapter / Const;
            }
            if (bookAdmin.TotalChapterPage <= 0)
            {
                bookAdmin.TotalChapterPage = 1;
            }
            if (request.CurrentPage <= 0)
            {
                bookAdmin.CurrentChapterPage = 1;
            }
            else if (request.CurrentPage > bookAdmin.TotalChapterPage)
            {
                bookAdmin.CurrentChapterPage = bookAdmin.TotalChapterPage;
            }
            bookAdmin.chapterAdminByIdBookViewModels = _mapper.Map<List<ChapterAdminByIdBookViewModel>>(await _context.Chapters
                .Where(x => x.BookId == request.Id)
                .Skip((bookAdmin.CurrentChapterPage - 1) * Const).Take(Const).ToListAsync(cancellationToken));

            var previous = (bookAdmin.CurrentChapterPage == 1) ?
                (bookAdmin.PreviousChapterPage = bookAdmin.CurrentChapterPage)
                : (bookAdmin.PreviousChapterPage = bookAdmin.CurrentChapterPage - 1);
            // if last chapter page, next return last chapter page
            var next = (bookAdmin.CurrentChapterPage == bookAdmin.TotalChapterPage) ?
                (bookAdmin.NextChapterPage = bookAdmin.CurrentChapterPage)
                : (bookAdmin.NextChapterPage = bookAdmin.CurrentChapterPage + 1);

            return bookAdmin;
        }
    }
}
