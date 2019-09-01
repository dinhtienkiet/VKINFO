using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.Search.Queries.SearchAll
{
    public class SearchQueryHandler : IRequestHandler<SearchQuery, SearchViewModel>
    {
        public readonly IVKDbContext _context;
        public SearchQueryHandler(IVKDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<SearchViewModel> Handle(SearchQuery request, CancellationToken cancellationToken)
        {
            var result = new SearchViewModel();
            result.Category = await _context.Categories.Include(u => u.BookCategories)
                    .Where(x => x.Name.Trim().ToLower().Contains(request.Text.Trim().ToLower()))
                    .ToListAsync(cancellationToken);

            result.Author = await _context.Authors.Include(u => u.Books)
                .Where(x => x.FullName.Trim().ToLower().Contains(request.Text.Trim().ToLower()))
                    .ToListAsync(cancellationToken);

            result.Genre = await _context.Genres.Include(u => u.BookGenres).ThenInclude(u => u.Book)
                    .Where(x => x.Name.Trim().ToLower().Contains(request.Text.Trim().ToLower()))
                    .ToListAsync(cancellationToken);
            result.Book = await _context.Books.Include(u => u.Chapters)
                    .Where(x => x.Title.Trim().ToLower().Contains(request.Text.Trim().ToLower()))
                    .ToListAsync(cancellationToken);
            result.Chapter = await _context.Chapters
                    .Where(x => x.Title.Trim().ToLower().Contains(request.Text.Trim().ToLower()))
                    .ToListAsync(cancellationToken);
            return result;
        }
    }
}
