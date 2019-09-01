using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.BooksAdmin.Commands.UpdateBookAdmin
{
    public class UpdateBookAdminCommand : IRequest<Object>
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int AuthorID { get; set; }
        public IList<int> CategoriesID { get; set; }
        public IList<int> GenreID { get; set; }
        public UpdateBookAdminCommand()
        {
            CategoriesID = new List<int>();
            GenreID = new List<int>();
        }
    }
}
