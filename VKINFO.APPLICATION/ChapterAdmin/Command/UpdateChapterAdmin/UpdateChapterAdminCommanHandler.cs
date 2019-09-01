using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.ChapterAdmin.Command.UpdateChapterAdmin
{
    public class UpdateChapterAdminCommanHandler : IRequestHandler<UpdateChapterAdminCommand, object>
    {
        private readonly IVKDbContext _context;

        public UpdateChapterAdminCommanHandler(IVKDbContext context)
        {
            _context = context;
        }

        public async Task<object> Handle(UpdateChapterAdminCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Chapters.SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                return null;
            }
            entity.Title = request.Title;
            entity.Content = request.Content;
            entity.Description = request.Description;
            entity.Status = request.Status;
            entity.DateModified = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);
            return entity;

        }
    }
}
