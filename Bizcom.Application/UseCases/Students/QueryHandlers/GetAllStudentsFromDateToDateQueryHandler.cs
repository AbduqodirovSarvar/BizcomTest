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
    public class GetAllStudentsFromDateToDateQueryHandler : IQueryHandler<GetAllStudentsFromDateToDateQuery, List<UserViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllStudentsFromDateToDateQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserViewModel>> Handle(GetAllStudentsFromDateToDateQuery request, CancellationToken cancellationToken)
        {
            int august12 = new DateTime(DateTime.Now.Year, 8, 12).DayOfYear;
            int september18 = new DateTime(DateTime.Now.Year, 9, 18).DayOfYear;

            var students = await _context.Users
                .Where(x => (_context.Students.Any(s => s.UserId == x.Id)) 
                    && (august12 <= x.BirthDate.DayOfYear & september18 >= x.BirthDate.DayOfYear))
                        .ToListAsync(cancellationToken);

            return _mapper.Map<List<UserViewModel>>(students);
        }
    }
}
