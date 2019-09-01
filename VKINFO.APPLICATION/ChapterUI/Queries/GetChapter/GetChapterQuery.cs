using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.ChapterUI.Queries.GetChapter
{
    public class GetChapterQuery : IRequest<ChapterViewModel>
    {
        public int Id { get; set; }
    }
}
