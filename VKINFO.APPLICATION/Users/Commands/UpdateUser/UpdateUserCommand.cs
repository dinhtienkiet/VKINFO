using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using VKINFO.APPLICATION.Users.Queries.GetUser;

namespace VKINFO.APPLICATION.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserViewModel>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
