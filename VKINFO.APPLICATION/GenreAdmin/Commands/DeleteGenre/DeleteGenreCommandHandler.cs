using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.GenreAdmin.Commands.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, object>
    {
        public readonly IVKDbContext _context;       
        public DeleteGenreCommandHandler(IVKDbContext Context)
        {       
            _context = Context;
        }
        public async Task<object> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Genres.Include(c => c.BookGenres).
                Where(c => c.Id == request.Id && c.Id != 1).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
            {
                return null;
            }
            if (entity.BookGenres.Count() != 0)
            {
                _context.BookGenres.RemoveRange(entity.BookGenres);
            }
            foreach (var iterm in entity.BookGenres)
            {
                var testIdGenre = await _context.BookGenres
                    .SingleOrDefaultAsync(u => u.GenreId == 1 && u.BookId == iterm.BookId, cancellationToken);
                if (testIdGenre == null)
                {
                    var bookGenre = new BookGenre
                    {
                        GenreId = 1,
                        BookId = iterm.BookId
                    };
                    _context.BookGenres.Add(bookGenre);
                }
            }
            _context.Genres.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}

