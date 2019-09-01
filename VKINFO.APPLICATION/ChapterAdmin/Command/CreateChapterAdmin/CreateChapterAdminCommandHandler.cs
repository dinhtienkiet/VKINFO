using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VKINFO.APPLICATION.Interfaces;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.ChapterAdmin.Command.CreateChapterAdmin
{
    public class CreateChapterAdminCommandHandler : IRequestHandler<CreateChapterAdminCommand, object>
    {
        private readonly IVKDbContext _context;

        public CreateChapterAdminCommandHandler(IVKDbContext context)
        {
            _context = context;
        }
        public async Task<object> Handle(CreateChapterAdminCommand request, CancellationToken cancellationToken)
        {
            var entity = new Chapter
            {
                BookId = request.BookId,
                Content = request.Content,
                Title = request.Title,
                Description = request.Description,
                Status = request.Status
            };
            _context.Chapters.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;    
        }
    }
}
