using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.GenreAdmin.Queries.GetAllGenreAdmin
{
    public class GenreAdminViewModel
    {
        
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public int Status { get; set; } 
        public DateTime DateCreated { get; set; } 
        public DateTime DateModified { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
