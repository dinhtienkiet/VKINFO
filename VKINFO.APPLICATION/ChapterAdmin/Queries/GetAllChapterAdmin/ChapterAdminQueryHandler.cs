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

namespace VKINFO.APPLICATION.ChapterAdmin.Queries.GetAllChapterAdmin
{
    public class ChapterAdminQueryHandler : IRequestHandler<ChapterAdminQuery, IList<Chapter>>
    {
        private readonly IVKDbContext _context;
        public ChapterAdminQueryHandler(IVKDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Chapter>> Handle(ChapterAdminQuery request, CancellationToken cancellationToken)
        {
            var entiy = await _context.Chapters.ToListAsync(cancellationToken);
            return entiy;
        }
    }
}
