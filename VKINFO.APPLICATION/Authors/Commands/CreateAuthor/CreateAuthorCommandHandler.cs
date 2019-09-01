using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VKINFO.APPLICATION.Interfaces;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.Authors.Commands.CreateAuthor
{
    class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        public readonly IVKDbContext _context;
        public CreateAuthorCommandHandler(IVKDbContext Context)
        {
            _context = Context;
        }
        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Author
            {
                FullName = request.Fullname,
                Nickname = request.Nickname,
                Description = request.Description,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Status = 1
            };

            _context.Authors.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
