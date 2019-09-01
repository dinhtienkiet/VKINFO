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

namespace VKINFO.APPLICATION.SearchUI.Queries.Search
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

            result.Categories = await _context.Categories.Include(r => r.BookCategories).ThenInclude(r => r.Book)
                    .Where(x => x.Name.Trim().ToLower().Contains(request.Text.Trim().ToLower()))
                    .ToListAsync(cancellationToken);

            result.Authors = await _context.Authors.Include(r => r.Books)
                .Where(x => x.FullName.Trim().ToLower().Contains(request.Text.Trim().ToLower()))
                    .ToListAsync(cancellationToken);

            result.Genres = await _context.Genres
                    .Where(x => x.Name.Trim().ToLower().Contains(request.Text.Trim().ToLower()))
                    .ToListAsync(cancellationToken);

            result.Books = await _context.Books
                    .Where(x => x.Title.Trim().ToLower().Contains(request.Text.Trim().ToLower()))
                    .ToListAsync(cancellationToken);

            result.Chapters = await _context.Chapters
                    .Where(x => x.Title.Trim().ToLower().Contains(request.Text.Trim().ToLower()))
                    .ToListAsync(cancellationToken);
            return result;
        }
    }
}
