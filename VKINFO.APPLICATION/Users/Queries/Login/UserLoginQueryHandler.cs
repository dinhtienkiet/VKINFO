using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;

namespace VKINFO.APPLICATION.Users.Queries.Login
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, UserLoginViewModel>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;

        public UserLoginQueryHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserLoginViewModel> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UserLoginViewModel>
                (await _context.Users.SingleOrDefaultAsync(u => u.Username.Equals(request.Username) &&
                u.Password.Equals(request.Password), cancellationToken));
            if(entity == null)
            {
                return null;
            }
            return entity;
        }
    }
}
