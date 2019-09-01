using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
