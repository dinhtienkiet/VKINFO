using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public int Id { get; set; }
    }    
}
