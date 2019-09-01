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

namespace VKINFO.APPLICATION.GenreList.Queries.GetGenreList
{
    public class GetGenreListQueryHandler : IRequestHandler<GetGenreListQuery, GenreListViewModel>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreListQueryHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GenreListViewModel> Handle(GetGenreListQuery request, CancellationToken cancellationToken)
        {
            var result = new GenreListViewModel();
            result.Genre = await _context.Genres
                    .Where(x => x.Id == request.Id && x.Id != 1)
                    .Include(x => x.BookGenres)
                    .ThenInclude(x => x.Book)
                    .SingleOrDefaultAsync(cancellationToken);

            result.BookGenres = _context.BookGenres
                .Include(r => r.Book)
                .Where(x => x.GenreId == request.Id).ToList();

            result.Genres = await _context.Genres
                .Where(x => x.Id != 1)
                .ToListAsync(cancellationToken);

            result.TotalBook = _context.BookGenres
                .Include(r => r.Book)
                .Where(x => x.GenreId == request.Id).ToList();

            int pageSize = 9;
            var totalBook = result.BookGenres.Count();
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

            result.BookGenres =  _context.BookGenres.Where(x => x.GenreId == request.Id && x.GenreId != 1)
                .Include(x => x.Book).Skip(pageSize * request.Page).Take(pageSize).ToList();

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
