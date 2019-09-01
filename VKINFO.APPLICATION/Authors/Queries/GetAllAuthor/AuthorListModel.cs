using System;
using System.Collections.Generic;
using System.Text;
using VKINFO.APPLICATION.Authors.Queries.GetAllAuthor;


namespace VKINFO.APPLICATION.Authors.Queries.GetAllAuthor
{
    public class AuthorListModel
    {
        public IList<AuthorAdminViewModel> ListAuthor { get; set; }
        public AuthorListModel()
        {
            ListAuthor = new List<AuthorAdminViewModel>();
        }
    }
}
