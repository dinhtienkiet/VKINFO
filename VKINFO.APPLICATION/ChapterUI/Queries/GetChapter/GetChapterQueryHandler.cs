using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.ChapterUI.Queries.GetChapter
{
    public class GetChapterQueryHandler : IRequestHandler<GetChapterQuery, ChapterViewModel>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public GetChapterQueryHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ChapterViewModel> Handle(GetChapterQuery request, CancellationToken cancellationToken)
        {
            //TODO : Performance
            var chapter = _mapper.Map<ChapterViewModel>(
                    await _context.Chapters
                    .Include(x => x.Book)
                    .Where(x => x.Id == request.Id).SingleOrDefaultAsync(cancellationToken));
            if (chapter == null)
            {
                // TODO: Handle null exception
            }
            else
            {
                var bookChapters = _context.Chapters.Where(x => x.BookId == chapter.BookId).Select(x => x.Id).ToList();
                // Get index of chapter
                var currentChapIndex = bookChapters.IndexOf(chapter.Id);
                // if first chapter, previous return first chapter
                var previous = (currentChapIndex == 0) ?
                    (chapter.Previous = 0)
                    : (chapter.Previous = bookChapters[currentChapIndex - 1]);
                // if last chapter, next return last chapter
                var next = (currentChapIndex == bookChapters.Count() - 1) ?
                    (chapter.Next = 0)
                    : (chapter.Next = bookChapters[currentChapIndex + 1]);
            }
            return chapter;
            // TODO: Set view model property
        }
    }
}
