using AutoMapper;
using Bizcom.Application.Abstractions;
using Bizcom.Application.Models.VIewModels;
using Bizcom.Application.UseCases.Students.Queries;
using Bizcom.Domain.Entities;
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
            List<User> students = await (from user in _context.Users
                                         join student in _context.Students on user.Id equals student.UserId
                                         where user.FirstName.ToLower().Contains(request.Name.ToLower())
                                         | user.LastName.ToLower().Contains(request.Name.ToLower())
                                         select user)
                                         .ToListAsync(cancellationToken);

            return _mapper.Map<List<UserViewModel>>(students);
        }
    }
}
