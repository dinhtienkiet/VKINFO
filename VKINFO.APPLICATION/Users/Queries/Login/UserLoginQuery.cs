using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VKINFO.APPLICATION.Users.Queries.Login
{
    public class UserLoginQuery : IRequest<UserLoginViewModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
