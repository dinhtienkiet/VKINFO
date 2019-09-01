using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.GenreAdmin.Commands.DeleteGenre
{
    public class DeleteGenreCommand : IRequest<object>
    {
        public int Id { get; set; }
    }
}
