using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.Authors.Commands.EditAuthor
{
    public class EditAuthorCommandHandler : IRequestHandler<EditAuthorCommand, Unit>
    {
        public readonly IVKDbContext _context;
        public EditAuthorCommandHandler(IVKDbContext Context)
        {
            _context = Context;
        }

        public async Task<Unit> Handle(EditAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Authors
                    .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                return Unit.Value;
            }
            else
            {
                entity.FullName = request.FullName;
                entity.Nickname = request.Nickname;
                entity.Description = request.Description;
                entity.DateCreated = DateTime.Now;
                entity.DateModified = DateTime.Now;
                entity.Status = request.Status;
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;

            }
            
        }
    }
}
