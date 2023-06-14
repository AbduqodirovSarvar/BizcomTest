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
    public class GetAllStudentsByNameContainQueryHandler : IQueryHandler<GetAllStudentsByNameContainQuery, List<UserViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllStudentsByNameContainQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserViewModel>> Handle(GetAllStudentsByNameContainQuery request, CancellationToken cancellationToken)
        {
            var students = await _context.Users
                .Where(x => (_context.Students.Any(s => s.UserId == x.Id)) 
                    && (x.FirstName.ToLower().Contains(request.Name.ToLower()) 
                        | x.LastName.ToLower().Contains(request.Name.ToLower())))
                            .ToListAsync(cancellationToken);
                                       
            return _mapper.Map<List<UserViewModel>>(students);
        }
    }
}
