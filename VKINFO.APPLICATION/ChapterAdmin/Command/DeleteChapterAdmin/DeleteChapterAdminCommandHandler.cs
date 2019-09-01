using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.ChapterAdmin.Command.DeleteChapterAdmin
{
    public class DeleteChapterAdminCommandHandler : IRequestHandler<DeleteChapterAdminCommand, object>
    {
        private readonly IVKDbContext _context;

        public DeleteChapterAdminCommandHandler(IVKDbContext context)
        {
            _context = context;
        }
        public async Task<object> Handle(DeleteChapterAdminCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Chapters.SingleOrDefaultAsync( u => u.Id == request.Id, cancellationToken);
            if(entity == null)
            {
                return null;
            }
            _context.Chapters.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
