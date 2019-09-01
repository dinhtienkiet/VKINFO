using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.ChapterAdmin.Queries.GetAllChapterAdmin
{
    public class ChapterAdminQuery : IRequest<IList<Chapter>>
    {
    }
}
