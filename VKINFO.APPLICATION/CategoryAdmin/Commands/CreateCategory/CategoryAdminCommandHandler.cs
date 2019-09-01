using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VKINFO.APPLICATION.Interfaces;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.CategoryAdmin.Commands.CreateCategory
{
    public class CategoryAdminCommandHandler : IRequestHandler<CategoryAdminCommand, int>
    {
        private readonly IVKDbContext _context;

        public CategoryAdminCommandHandler(IVKDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CategoryAdminCommand request, CancellationToken cancellationToken)
        {
            var entity = new Category()
            {
                Name = request.Name,
                Description = request.Description,
                Status = request.Status
            };
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
