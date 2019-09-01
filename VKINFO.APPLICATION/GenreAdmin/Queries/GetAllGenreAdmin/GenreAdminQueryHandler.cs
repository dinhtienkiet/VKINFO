using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKINFO.APPLICATION.Interfaces;
using System.Linq;
using VKINFO.DOMAIN.Entities;

namespace VKINFO.APPLICATION.GenreAdmin.Queries.GetAllGenreAdmin
{
    public class GenreAdminQueryHandler : IRequestHandler<GenreAdminQuery, IList<GenreAdminViewModel>>
    {
        public readonly IVKDbContext _context;
        public readonly IMapper _mapper;
        public GenreAdminQueryHandler(IVKDbContext dbContext, IMapper _Mapper)
        {
            _context = dbContext;
            _mapper = _Mapper;
        }
        public async Task<IList<GenreAdminViewModel>> Handle(GenreAdminQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<IList<GenreAdminViewModel>>
                (await _context.Genres.Include(u => u.BookGenres).Where(u => u.Id != 1).ToListAsync(cancellationToken));
            return result; 
        }
    }
    
}
