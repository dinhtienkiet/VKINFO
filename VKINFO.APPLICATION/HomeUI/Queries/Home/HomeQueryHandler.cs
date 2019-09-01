using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.HomeUI.Queries.Home
{
    public class HomeQueryHandler : IRequestHandler<HomeQuery, HomeViewModel>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public HomeQueryHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HomeViewModel> Handle(HomeQuery request, CancellationToken cancellationToken)
        {
            var result = new HomeViewModel();

            result.Genres = await _context.Genres
                           .ToListAsync(cancellationToken);

            result.Authors = await _context.Authors
                           .ToListAsync(cancellationToken);

            result.Books = await _context.Books
                           .Include(r => r.BookCategories)
                           .ToListAsync(cancellationToken);

            result.Categories = await _context.Categories
                           .Include(r => r.BookCategories)
                           .ToListAsync(cancellationToken);

            Random rnd = new Random();
            result.HotBooks = await _context.Books
                           .Skip(rnd.Next(0, _context.Books.Count() - 5))
                           .Take(4)
                           .ToListAsync(cancellationToken);

            result.GoodBooks = await _context.Books
                           .Skip(rnd.Next(0, _context.Books.Count() - 5))
                           .Take(4)
                           .ToListAsync(cancellationToken);

            result.HomeBooks = _context.Books.ToList();

            int pageSize = 5;
            var totalBook = result.Books.Count();

            if (result == null)
            {
                return null;
            }

            if (totalBook % pageSize > 0)
            {
                result.TotalPage = (int)totalBook / pageSize + 1;
            }
            else
            {
                result.TotalPage = (int)totalBook / pageSize;
            }

            if (request.Page <= 0)
            {
                request.Page = 0;
            }

            if (request.Page > 0 && request.Page <= result.TotalPage)
            {
                request.Page = request.Page - 1;
            }

            if (request.Page > result.TotalPage)
            {
                request.Page = result.TotalPage - 1;
            }

            result.CurrentPage = request.Page + 1;

            result.Books = await _context.Books
                .Skip((result.CurrentPage - 1) * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken);

            // if first chapter page, previous return first chapter page
            var previous = (result.CurrentPage == 1) ?
                (result.PreviousPage = result.CurrentPage)
                : (result.PreviousPage = result.CurrentPage - 1);

            // if last chapter page, next return last chapter page
            var next = (result.CurrentPage == result.TotalPage) ?
                (result.NextPage = result.CurrentPage)
                : (result.NextPage = result.CurrentPage + 1);

            return result;
        }
    }
}
