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
namespace VKINFO.APPLICATION.GenreAdmin.Queries.GetGenreAdmin
{
    public class GetGenreQueryhandler : IRequestHandler<GetGenreAdminQuery, GenreDetailAdminViewModel>
    {
        public readonly IVKDbContext _context;
        public readonly IMapper _mapper;
        public GetGenreQueryhandler(IVKDbContext Context, IMapper Mapper)
        {
            _context = Context;
            _mapper = Mapper;
        }
        public async Task<GenreDetailAdminViewModel> Handle(GetGenreAdminQuery request, CancellationToken cancellationToken)
        {
            int pageSize = 1;
            var Genre = _mapper.Map<GenreDetailAdminViewModel>(
                 await _context.Genres
                 .Where(x => x.Id == request.Id && x.Id != 1)
                 .Include(x => x.BookGenres)
                    .ThenInclude(x => x.Book)
                 .SingleOrDefaultAsync(cancellationToken));
            if (Genre == null)
            {
                return null;
            }
            var totalBook = Genre.BookGenres.Count();
            if (totalBook % pageSize > 0)
            {
                Genre.TotalPage = (int)totalBook / pageSize + 1;
            }
            else
            {
                Genre.TotalPage = (int)totalBook / pageSize;
            }
            if (request.Page < 1)
            {
                Genre.CurrentPage = 1;
            }
            else if (request.Page > Genre.TotalPage)
            {
                Genre.CurrentPage = Genre.TotalPage;
            }
            else
            {
                Genre.CurrentPage = request.Page;
            }
            Genre.BookGenres = _context.BookGenres.Where(x => x.GenreId == request.Id && x.GenreId != 1)
                .Include(x => x.Book).Skip(pageSize * Genre.CurrentPage - pageSize).Take(pageSize).ToList();
            // if first chapter page, previous return first chapter page
            var previous = (Genre.CurrentPage == 1) ?
                (Genre.PreviousPage = Genre.CurrentPage)
                : (Genre.PreviousPage = Genre.CurrentPage - 1);

            // if last chapter, next return last chapter
            var next = (Genre.CurrentPage == Genre.TotalPage) ?
                (Genre.NextPage = Genre.CurrentPage)
                : (Genre.NextPage = Genre.CurrentPage + 1);

            return Genre;
        }
    }
}
