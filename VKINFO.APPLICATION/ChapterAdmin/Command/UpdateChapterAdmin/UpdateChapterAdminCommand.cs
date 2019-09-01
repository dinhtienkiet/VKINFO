using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.ChapterAdmin.Command.UpdateChapterAdmin
{
    public class UpdateChapterAdminCommand : IRequest<object>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BookId { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime DateModified { get; set; }
    }
}
