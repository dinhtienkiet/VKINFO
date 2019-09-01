using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.BooksAdmin.Commands.UpdateBookAdmin;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.ChapterAdmin.Queries.GetChapterById
{
    public class ChapterAdminViewModelQueryHandler : IRequestHandler<ChapterAdminViewModelQuery, ChapterAdminByIdBookViewModel>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;
        public ChapterAdminViewModelQueryHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ChapterAdminByIdBookViewModel> Handle(ChapterAdminViewModelQuery request, CancellationToken cancellationToken)
        {
            var chapter = _mapper.Map<ChapterAdminByIdBookViewModel>
               (await _context.Chapters.Include(c =>c.Book).SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken));
            if (chapter == null)
            {
                return null;
            }
            if (chapter.StatusBook == 1)
            {
                return null;
            }
            return chapter;
        }
    }
}
