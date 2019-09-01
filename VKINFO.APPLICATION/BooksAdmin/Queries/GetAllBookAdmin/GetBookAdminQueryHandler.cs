using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.BooksAdmin.Queries.GetAllBookAdmin;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.Queries.BooksAdmin.GetAllBookAdmin
{
    public class GetBookAdminQueryHandler : IRequestHandler<GetAllBookAdminQuery, BookAdminViewModelList>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public GetBookAdminQueryHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BookAdminViewModelList> Handle(GetAllBookAdminQuery request, CancellationToken cancellationToken)
        {
            var Const = 5;
            var bookListViewModel = _mapper.Map<IList<BookAdminViewModel>>
                (await _context.Books.Include(u => u.Author).Include(u => u.Chapters).ToListAsync(cancellationToken));
            BookAdminViewModelList bookAdminViewModelList = new BookAdminViewModelList()
            {
                bookAdminViewModels = bookListViewModel
            };
            bookAdminViewModelList.CurrentPage = request.CurrentPage;
            var totalBook = bookAdminViewModelList.bookAdminViewModels.Count();
            if (totalBook % Const > 0)
            {
                bookAdminViewModelList.TotalPage = (int)totalBook / Const + 1;
            }
            else
            {
                bookAdminViewModelList.TotalPage = (int)totalBook / Const;
            }
            if (bookAdminViewModelList.TotalPage <= 0)
            {
                bookAdminViewModelList.TotalPage = 1;
            }
            if (request.CurrentPage <= 0)
            {
                bookAdminViewModelList.CurrentPage = 1;
            }
            if (request.CurrentPage > bookAdminViewModelList.TotalPage)
            {
                bookAdminViewModelList.CurrentPage = bookAdminViewModelList.TotalPage;
            }
            bookAdminViewModelList.bookAdminViewModels = _mapper.Map<IList<BookAdminViewModel>>
                (await _context.Books.Include(u => u.Author).Include(u => u.Chapters).
                Skip((bookAdminViewModelList.CurrentPage - 1) * Const).Take(Const).ToListAsync(cancellationToken));
            // if first chapter page, previous return first chapter page
            var previous = (bookAdminViewModelList.CurrentPage == 1) ?
                (bookAdminViewModelList.PreviousPage = bookAdminViewModelList.CurrentPage)
                : (bookAdminViewModelList.PreviousPage = bookAdminViewModelList.CurrentPage - 1);
            // if last chapter, next return last chapter
            var next = (bookAdminViewModelList.CurrentPage == bookAdminViewModelList.TotalPage) ?
                (bookAdminViewModelList.NextPage = bookAdminViewModelList.CurrentPage)
                : (bookAdminViewModelList.NextPage = bookAdminViewModelList.CurrentPage + 1);

            return bookAdminViewModelList;
        }
    }

}