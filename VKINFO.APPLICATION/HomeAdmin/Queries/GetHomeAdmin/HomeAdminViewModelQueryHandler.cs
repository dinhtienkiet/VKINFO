using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.HomeAdmin.Queries.GetHomeAdmin
{
    public class HomeAdminViewModelQueryHandler : IRequestHandler<HomeAdminViewModelQuery, HomeAdminViewModel>
    {
        public readonly IVKDbContext _context;
        public HomeAdminViewModelQueryHandler(IVKDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<HomeAdminViewModel> Handle(HomeAdminViewModelQuery request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.Include(u => u.BookGenres).ThenInclude(bc => bc.Book).ToListAsync(cancellationToken);
            var category = await _context.Categories.Include(u => u.BookCategories).ThenInclude(bc => bc.Book).ToListAsync(cancellationToken);
            var author = await _context.Authors.ToListAsync(cancellationToken);
            var book = await _context.Books.ToListAsync(cancellationToken);
            var chapter = await _context.Chapters.ToListAsync(cancellationToken);
            var homeAdminViewModel = new HomeAdminViewModel
            {
                genres = genre,
                authors = author,
                books = book,
                categories = category,
                chapters = chapter
            };
            return homeAdminViewModel;
        }
    }
}
