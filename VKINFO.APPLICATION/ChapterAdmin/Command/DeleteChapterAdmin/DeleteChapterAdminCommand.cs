using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.ChapterAdmin.Command.DeleteChapterAdmin
{
    public class DeleteChapterAdminCommand : IRequest<object>
    {
        public int Id { get; set; }

    }
}
