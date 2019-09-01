using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VKINFO.APPLICATION.Interfaces;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.CategoryAdmin.Commands.UpdateCategory
{
    public class UpdateCategoryAdminCommandHandler : IRequestHandler<UpdateCategoryAdminCommand, object>
    {
        private readonly IVKDbContext _context;

        public UpdateCategoryAdminCommandHandler(IVKDbContext context)
        {
            _context = context;
        }

        public async Task<object> Handle(UpdateCategoryAdminCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if(entity == null)
            {
                return null;
            }
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Status = request.Status;
            entity.DateModified = DateTime.Now;
           /* foreach (var iterm in entity.BookCategories)
            {
                var categoryEntity = await _context.BookCategories.SingleOrDefaultAsync(c => c.BookId == request.Id, cancellationToken);
            }*/
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}