using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Username { get; set; } // Username (length: 50)

        public string Password { get; set; } // Password (length: 64)

        public int Role { get; set; } // Role
    }
}
