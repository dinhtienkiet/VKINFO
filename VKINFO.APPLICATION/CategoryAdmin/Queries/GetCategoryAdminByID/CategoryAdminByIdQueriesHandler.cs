using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.CategoryAdmin.Queries.GetAllCategoryAdmin;
using VKINFO.APPLICATION.Interfaces;
using VKINFO.APPLICATION.Queries.BooksAdmin.GetAllBookAdmin;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.CategoryAdmin.Queries.GetCategoryAdminByID
{
    public class CategoryAdminByIdQueriesHandler : IRequestHandler<CategoryAdminByIdQueries, CategoryAdminViewModelById>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public CategoryAdminByIdQueriesHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CategoryAdminViewModelById> Handle(CategoryAdminByIdQueries request, CancellationToken cancellationToken)
        {
            var Const = 5;
            var category = _mapper.Map<CategoryAdminViewModelById>(await _context.Categories
                .Include(uc => uc.BookCategories).ThenInclude(u => u.Book).ThenInclude(a => a.Author)
                .Include(uc => uc.BookCategories).ThenInclude(u => u.Book).ThenInclude(a => a.Chapters)
                .Where(u => u.Id == request.Id).SingleOrDefaultAsync(cancellationToken));
            if (category == null)
            {
                return null;
            }
            category.CurrentPage = request.CurrentPage;

            var totalBook = category.BookCategories.Count();
            if (totalBook % Const > 0)
            {
                category.TotalPage = (int)totalBook / Const + 1;
            }
            else
            {
                category.TotalPage = (int)totalBook / Const;
            }
            if (category.TotalPage <= 0)
            {
                category.TotalPage = 1;
            }
            if (request.CurrentPage <= 0)
            {
                category.CurrentPage = 1;
            }
            else if (request.CurrentPage > category.TotalPage)
            {
                category.CurrentPage = category.TotalPage;
            }
            category.BookCategories = await _context.BookCategories
                .Include(u => u.Book).Where(u => u.CategoryId == request.Id)
                .Skip((category.CurrentPage - 1)* Const).Take(Const).ToListAsync(cancellationToken);
            // if first chapter page, previous return first chapter page
            var previous = (category.CurrentPage == 1) ?
                (category.PreviousPage = category.CurrentPage)
                : (category.PreviousPage = category.CurrentPage - 1);
            // if last chapter, next return last chapter
            var next = (category.CurrentPage == category.TotalPage) ?
                (category.NextPage = category.CurrentPage)
                : (category.NextPage = category.CurrentPage + 1);
            return category;
        }
    }
}
