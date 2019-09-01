using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.Users.Queries.GetUser
{    
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }

        public int Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        //TODO: Base on domain driven to add more property
    }
}
