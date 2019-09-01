using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.BooksAdmin.Commands.DeletBookAdmin
{
    public class DeleteBookAdminCommandHandler : IRequestHandler<DeleteBookAdminCommand, object>
    {
        private readonly IVKDbContext _context;

        public DeleteBookAdminCommandHandler(IVKDbContext context)
        {
            _context = context;
        }
        public async Task<object> Handle(DeleteBookAdminCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Books.Include(b => b.Chapters).SingleOrDefaultAsync(b => b.Id == request.Id,cancellationToken);
            if(entity == null)
            {
                return null;
            }
            if(entity.Chapters.Count() != 0)
            {
                return null;
            }
            _context.Books.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
