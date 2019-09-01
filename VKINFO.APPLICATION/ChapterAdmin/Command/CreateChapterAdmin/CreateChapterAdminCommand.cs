using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.ChapterAdmin.Command.CreateChapterAdmin
{
    public class CreateChapterAdminCommand : IRequest<object>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int BookId { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
