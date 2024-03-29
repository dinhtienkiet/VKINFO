﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace VKINFO.APPLICATION.GenreAdmin.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
