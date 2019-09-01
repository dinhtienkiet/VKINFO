using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.Authors.Commands.DeleteAuthor
{

    class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, object>
    {
        public readonly IVKDbContext _context;
        public DeleteAuthorCommandHandler(IVKDbContext Context)
        {
            _context = Context;
        }
        public async Task<object> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Authors.Where(u => u.Id == request.Id).SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return null;
            }
            var hasBook = await _context.Books.Where(o => o.AuthorId == entity.Id).FirstOrDefaultAsync(cancellationToken);
            if (hasBook != null)
            {
                return null;
            }
            else
            {
                _context.Authors.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
           
        }
    }
}
