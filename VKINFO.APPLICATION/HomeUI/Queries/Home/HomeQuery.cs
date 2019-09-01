using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.APPLICATION.HomeUI.Queries.Home
{
    public class HomeQuery : IRequest<HomeViewModel>
    {
        public int Page { get; set; }
    }
}
