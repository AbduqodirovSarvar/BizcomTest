using AutoMapper;
using Bizcom.Application.Abstractions;
using Bizcom.Application.Models.VIewModels;
using Bizcom.Application.UseCases.Teachers.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Teachers.QueryHandlers
{
    public class GetAllTeachersOverNAgeQueryHandler : IQueryHandler<GetAllTeachersOverNAgeQuery, List<UserViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllTeachersOverNAgeQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserViewModel>> Handle(GetAllTeachersOverNAgeQuery request, CancellationToken cancellationToken)
        {
            var teachers = await _context.Users
                .Where(x => (_context.Teachers.Any(t => t.UserId == x.Id)) 
                    && (DateTime.Now.Year - x.BirthDate.Year) > 55 
                        & (DateTime.Today.DayOfYear - x.BirthDate.DayOfYear) >= 0)
                            .ToListAsync(cancellationToken);

            return _mapper.Map<List<UserViewModel>>(teachers);
        }
    }
}
