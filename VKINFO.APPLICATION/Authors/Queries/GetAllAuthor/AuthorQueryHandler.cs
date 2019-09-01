using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Authors.Commands;
using VKINFO.APPLICATION.Interfaces;


namespace VKINFO.APPLICATION.Authors.Queries.GetAllAuthor
{
    public class AuthorQueryHandler : IRequestHandler<AuthorQuery, IList<AuthorAdminViewModel>>
    {
        public readonly IVKDbContext _context;
        public readonly IMapper _mapper;
        public AuthorQueryHandler(IVKDbContext dbContext, IMapper _Mapper)
        {
            _context = dbContext;
            _mapper = _Mapper;
        }
        public async Task<IList<AuthorAdminViewModel>> Handle(AuthorQuery request, CancellationToken cancellationToken)
        {           
            var listAuthorMap =_mapper.Map<IList<AuthorAdminViewModel>>
                (await _context.Authors.Include(u => u.Books).ToListAsync(cancellationToken));
            return listAuthorMap;
        }
    }
}
