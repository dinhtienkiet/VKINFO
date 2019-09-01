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

namespace VKINFO.APPLICATION.CategoryAdmin.Commands.DeleteCategory
{
    public class DeleteCategoryAdminCommandHandler : IRequestHandler<DeleteCategoryAdminCommand, object>
    {
        private readonly IVKDbContext _context;

        public DeleteCategoryAdminCommandHandler(IVKDbContext context)
        {
            _context = context;
        }
        public async Task<object> Handle(DeleteCategoryAdminCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.Include(c => c.BookCategories).
                Where(c => c.Id == request.Id && c.Id != 1).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
            {
                return null;
            }
            if (entity.BookCategories.Count() != 0)
            {
                _context.BookCategories.RemoveRange(entity.BookCategories);
            }
            foreach (var iterm in entity.BookCategories)
            {
                var testIdCategory = await _context.BookCategories
                    .SingleOrDefaultAsync(u => u.CategoryId == 1 && u.BookId == iterm.BookId, cancellationToken);
                if (testIdCategory == null)
                {
                    var bookCategory = new BookCategory
                    {
                        CategoryId = 1,
                        BookId = iterm.BookId
                    };
                    _context.BookCategories.Add(bookCategory);
                }
            }
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
