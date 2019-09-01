using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.ChapterAdmin.Queries.GetChapterById
{
    public class ChapterByIdViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
    }
}
