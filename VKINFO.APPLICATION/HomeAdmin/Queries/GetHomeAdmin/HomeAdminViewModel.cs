using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.HomeAdmin.Queries.GetHomeAdmin
{
    public class HomeAdminViewModel
    {
        public IList<Genre> genres { get; set; }
        public IList<Category> categories { get; set; }
        public IList<Book> books { get; set; }
        public IList<Author> authors { get; set; }
        public IList<Chapter> chapters { get; set; }
    }
}
