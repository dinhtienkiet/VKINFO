using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VKINFO.APPLICATION.Interfaces;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.BooksAdmin.Commands.CreateBookAdmin
{
    public class CreateBookAdminCommandHandler : IRequestHandler<CreateBookAdminCommand, int>
    {
        private readonly IVKDbContext _context;

        public CreateBookAdminCommandHandler(IVKDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateBookAdminCommand request, CancellationToken cancellationToken)
        {
            var entity = new Book
            {
                Title = request.Title,
                Description = request.Description,               
                Image = request.Image,
                Slug = request.Slug,
                AuthorId = request.AuthorID         
            };
            _context.Books.Add(entity);
            foreach (var idCateBook in request.CategoriesID)
            {
                var categoryBook = new BookCategory
                {
                    BookId = entity.Id,
                    CategoryId = idCateBook
                };
                _context.BookCategories.Add(categoryBook);
            }
            foreach (var idGenre in request.GenreID)
            {
                var genreBook = new BookGenre
                {
                    BookId = entity.Id,
                    GenreId = idGenre
                    
                };
                _context.BookGenres.Add(genreBook);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
