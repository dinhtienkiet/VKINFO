using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;
using VKINFO.APPLICATION.Users.Queries.GetUser;

namespace VKINFO.APPLICATION.BooksUI.Queries.GetBook
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookViewModel>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public GetBookQueryHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookViewModel> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            //TODO : Performance
            var book = new BookViewModel();
            book.Book = await _context.Books
                    .Include(x => x.Author)
                    .Include(x => x.BookCategories)
                        .ThenInclude(bc => bc.Category)
                    .Include(x => x.BookGenres)
                        .ThenInclude(bg => bg.Genre)
                    .Where(x => x.Id == request.Id).SingleOrDefaultAsync(cancellationToken);

            Random rnd = new Random();

            book.RelatedBooks = await _context.Books
                .Where(x => x.Id != request.Id)
                .Skip(rnd.Next(0, _context.Books.Count() - 5))
                .Take(4)
                .ToListAsync(cancellationToken);

            var chapters = await _context.Chapters.Where(x => x.BookId == request.Id).ToListAsync();
            var totalChapters = chapters.Count();
            const int itemPerPage = 10;

            if (totalChapters % itemPerPage > 0)
            {
                book.TotalChapterPage = (int)totalChapters / itemPerPage + 1;
            }
            else
            {
                book.TotalChapterPage = (int)totalChapters / itemPerPage;
            }

            if (request.CurrentPage <= 0)
            {
                request.CurrentPage = 0;
            }

            if (request.CurrentPage > 0 && request.CurrentPage <= book.TotalChapterPage)
            {
                request.CurrentPage = request.CurrentPage - 1;
            }

            if (request.CurrentPage > book.TotalChapterPage)
            {
                request.CurrentPage = book.TotalChapterPage - 1;
            }

            book.CurrentChapterPage = request.CurrentPage + 1;

            book.Chapters = await _context.Chapters
                .Where(x => x.BookId == request.Id)
                .Skip((book.CurrentChapterPage - 1) * itemPerPage).Take(itemPerPage).ToListAsync(cancellationToken);

            // if first chapter page, previous return first chapter page
            var previous = (book.CurrentChapterPage == 0) ?
                (book.PreviousChapterPage = book.CurrentChapterPage)
                : (book.PreviousChapterPage = book.CurrentChapterPage - 1);
            // if last chapter page, next return last chapter page
            var next = (book.CurrentChapterPage == book.TotalChapterPage) ?
                (book.NextChapterPage = book.CurrentChapterPage)
                : (book.NextChapterPage = book.CurrentChapterPage + 1);

            return book;
            // TODO: Set view model property
        }
    }
}
