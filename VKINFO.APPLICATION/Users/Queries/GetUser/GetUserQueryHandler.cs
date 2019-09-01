using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VKINFO.APPLICATION.Interfaces;
using VKINFO.APPLICATION.Users.Queries.GetUser;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.Users.Commands.CreateUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserViewModel>(
                    await _context.Users.Where(x => x.Id == request.Id).SingleOrDefaultAsync(cancellationToken));

            if (user == null)
            {
               // TODO: Handle null exception
            }

            // TODO: Set view model property

            return user;
        }

    }
}
