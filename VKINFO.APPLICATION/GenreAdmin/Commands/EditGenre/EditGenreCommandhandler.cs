using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.GenreAdmin.Commands.EditGenre
{
    public class EditGenreCommandhandler : IRequestHandler<EditGenreCommand, object>
    {
        public readonly IVKDbContext _context;
        public EditGenreCommandhandler(IVKDbContext Context)
        {
            _context = Context;
        }

        public async Task<object> Handle(EditGenreCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Genres
                    .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                return null;
            }
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.DateModified = DateTime.Now;
            entity.Status = request.Status;
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
