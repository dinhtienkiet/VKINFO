using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VKINFO.DOMAIN.Entities;
using VKINFO.APPLICATION.Interfaces;
namespace VKINFO.APPLICATION.GenreAdmin.Commands.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
    {
        public readonly IVKDbContext _context;
        public CreateGenreCommandHandler(IVKDbContext Context)
        {
            _context = Context;
        }
        public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var entity = new Genre
            {
                Name = request.Name,
                Description = request.Description,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Status = 1
            };

            _context.Genres.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
