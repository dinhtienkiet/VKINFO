using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;
using VKINFO.APPLICATION.Users.Queries.GetUser;

namespace VKINFO.APPLICATION.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserViewModel>
    {
        private readonly IVKDbContext _context;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IVKDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u =>u.Id == request.Id,cancellationToken);
            if(user == null)
            {
                return null;
            }
            user.Username = request.Username;
            user.Password = request.Password;
            user.DateModified = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);
            var userModel = _mapper.Map<UserViewModel>(user);
            return userModel;
        }
    }
}
