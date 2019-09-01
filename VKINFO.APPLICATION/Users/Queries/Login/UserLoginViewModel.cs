using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.Users.Queries.Login
{
    public class UserLoginViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }

        public int Status { get; set; }
    }
}
