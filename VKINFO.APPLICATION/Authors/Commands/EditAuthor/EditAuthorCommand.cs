using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using VKINFO.DOMAIN.Entities;
using VKINFO.APPLICATION.Authors.Queries.GetAllAuthor;
namespace VKINFO.APPLICATION.Authors.Commands.EditAuthor

{
    public class EditAuthorCommand : IRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}

    

