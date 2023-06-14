using AutoMapper;
using Bizcom.Application.Abstractions;
using Bizcom.Application.Models.VIewModels;
using Bizcom.Application.UseCases.Students.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Students.QueryHandlers
{
    public class GetAllStudentToNYearsOldQueryHandler : IQueryHandler<GetAllStudentToNYearsOldQuery, List<UserViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllStudentToNYearsOldQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserViewModel>> Handle(GetAllStudentToNYearsOldQuery request, CancellationToken cancellationToken)
        {
            var students = await _context.Users
                .Where(x => (_context.Students.Any(s => s.UserId == x.Id)) 
                    && (DateTime.Today.Year - x.BirthDate.Year) <= request.Age 
                        & (DateTime.Today.DayOfYear - x.BirthDate.DayOfYear) >= 0)
                            .ToListAsync(cancellationToken);

            return _mapper.Map<List<UserViewModel>>(students);
        }
    }
}
