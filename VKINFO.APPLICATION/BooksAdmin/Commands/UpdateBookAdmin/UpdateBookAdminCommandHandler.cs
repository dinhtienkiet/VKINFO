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

namespace VKINFO.APPLICATION.BooksAdmin.Commands.UpdateBookAdmin
{
    public class UpdateBookAdminCommandHandler : IRequestHandler<UpdateBookAdminCommand,object>
    {
        private readonly IVKDbContext _context;

        public UpdateBookAdminCommandHandler(IVKDbContext context)
        {
            _context = context;
        }

        public async Task<object> Handle(UpdateBookAdminCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Books.Include(b => b.BookCategories).Include(b => b.Chapters).Include(b =>b.BookGenres)
                .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if(entity == null)
            {
                return null;
            }
            if(request.Image != null)
            {
                entity.Image = request.Image;
            }
            if (entity.Chapters.Count()!=0 && !entity.Chapters.Select(c =>c.Status).Contains(2))
            {
                entity.Status = request.Status;
            }
            entity.Slug = request.Slug;
            entity.Title = request.Title;
            entity.AuthorId = request.AuthorID;
            entity.DateModified = DateTime.Now;
            entity.Description = request.Description;
            _context.BookCategories.RemoveRange(entity.BookCategories);
            _context.BookGenres.RemoveRange(entity.BookGenres);
            foreach (var idCateBook in request.CategoriesID)
            {
                var category = new BookCategory
                {
                    BookId = entity.Id,
                    CategoryId = idCateBook
                };
                _context.BookCategories.Add(category);
            }
            foreach (var idGenre in request.GenreID)
            {
                var genre = new BookGenre
                {
                    BookId = entity.Id,
                    GenreId = idGenre
                };
                _context.BookGenres.Add(genre);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
