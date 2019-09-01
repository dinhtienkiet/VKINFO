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

namespace VKINFO.APPLICATION.Authors.Queries.GetAuthor
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, AuthorViewModel>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorQueryHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<AuthorViewModel> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            /*var author = _mapper.Map<AuthorViewModel>(
                    await _context.Authors.Where(x => x.Id == request.Id).Include(x => x.Books).SingleOrDefaultAsync(cancellationToken));
                    return author;*/
            int pageSize = 2;
            var author = _mapper.Map<AuthorViewModel>(
                 await _context.Authors
                 .Where(x => x.Id == request.Id)
                 .Include(x => x.Books)
                 .SingleOrDefaultAsync(cancellationToken));
                if (author == null)
                {
                    return null;
                }
            author.CurrentPage = request.Page;
            var totalBook = author.Books.Count();
            if (totalBook % pageSize > 0)
            {
                author.TotalPage = (int)totalBook / pageSize + 1;
            }
            else
            {
                author.TotalPage = (int)totalBook / pageSize;
            }
            if (request.Page < 1)
            {
                author.CurrentPage = 1;
            }
            else if (request.Page > author.TotalPage)
            {
                author.CurrentPage = author.TotalPage;
            }
            else
            {
                author.CurrentPage = request.Page;
            }
            author.Books = _context.Books.Where(x => x.AuthorId == request.Id)
                .Skip(pageSize * author.CurrentPage - pageSize).Take(pageSize).ToList();

            // if first chapter page, previous return first chapter page
            var previous = (author.CurrentPage == 0) ?
                (author.PreviousPage = author.CurrentPage)
                : (author.PreviousPage = author.CurrentPage - 1);

            // if last chapter, next return last chapter
            var next = (author.CurrentPage == author.TotalPage) ?
                (author.NextPage = author.CurrentPage)
                : (author.NextPage = author.CurrentPage + 1);

            return author;
        }

    }
}
