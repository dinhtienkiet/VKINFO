using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.AuthorUI.Queries.GetAuthorList
{
    public class GetAuthorListQueryHandler : IRequestHandler<GetAuthorListQuery, AuthorListViewModel>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorListQueryHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorListViewModel> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            //TODO : Performance
            var result = new AuthorListViewModel();
            result.Author = await _context.Authors
                    .Where(x => x.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);
            
            var book = await _context.Books.Where(x => x.AuthorId == request.Id).ToListAsync();
            var totalBook = book.Count();
            const int itemPerPage = 9;

            if (totalBook % itemPerPage > 0)
            {
                result.TotalPage = (int)totalBook / itemPerPage + 1;
            }
            else
            {
                result.TotalPage = (int)totalBook / itemPerPage;
            }

            if (request.CurrentPage <= 0)
            {
                request.CurrentPage = 0;
            }

            if (request.CurrentPage > 0 && request.CurrentPage <= result.TotalPage)
            {
                request.CurrentPage = request.CurrentPage - 1;
            }

            if (request.CurrentPage > result.TotalPage)
            {
                request.CurrentPage = result.TotalPage - 1;
            }

            result.CurrentPage = request.CurrentPage + 1;

            result.Books = await _context.Books
                .Where(x => x.AuthorId == request.Id)
                .Skip((result.CurrentPage - 1) * itemPerPage).Take(itemPerPage)
                .ToListAsync(cancellationToken);

            result.AuthorList = await _context.Authors
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
            // TODO: Set view model property
        }
    }
}
