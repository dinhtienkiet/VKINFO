using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.CategoryAdmin.Queries.GetAllCategoryAdmin
{
    public class CategoryAdminQueriesHandler : IRequestHandler<CategoryAdminQueries, IList<CategoryAdminViewModel>>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public CategoryAdminQueriesHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<CategoryAdminViewModel>> Handle(CategoryAdminQueries request, CancellationToken cancellationToken)
        {
            var CategoryList = _mapper.Map<IList<CategoryAdminViewModel>>
                (await _context.Categories.Include(u => u.BookCategories).ToListAsync(cancellationToken));
            return CategoryList;
        }
    }
}
