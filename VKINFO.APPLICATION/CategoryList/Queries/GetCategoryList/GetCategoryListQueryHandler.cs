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

namespace VKINFO.APPLICATION.BookCategoryList.Queries.GetBookCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, CategoryListViewModel>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryListViewModel> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            //TODO : Performance
            var result = new CategoryListViewModel();
            result.Category = await _context.Categories
                    .Where(x => x.Id == request.Id)
                    .Include(x => x.BookCategories)
                    .ThenInclude(x => x.Book)
                    .SingleOrDefaultAsync(cancellationToken);

            result.BookCategories = await _context.BookCategories
                .Include(r => r.Book)
                .Where(x => x.CategoryId == request.Id)
                .ToListAsync(cancellationToken);

            result.Categories = await _context.Categories
                .ToListAsync(cancellationToken);

            result.TotalBook = await _context.BookCategories
                .Include(r => r.Book)
                .Where(x => x.CategoryId == request.Id)
                .ToListAsync(cancellationToken);

            int pageSize = 9;
            var totalBook = result.BookCategories.Count();
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

            result.BookCategories = _context.BookCategories.Where(x => x.CategoryId == request.Id)
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
