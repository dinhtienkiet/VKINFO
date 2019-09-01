using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using VKINFO.APPLICATION.BooksAdmin.Commands.UpdateBookAdmin;

namespace VKINFO.APPLICATION.ChapterAdmin.Queries.GetChapterById
{
    public class ChapterAdminViewModelQuery : IRequest<ChapterAdminByIdBookViewModel>
    {
        public int Id { get; set; }
    }
}
