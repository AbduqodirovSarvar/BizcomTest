using AutoMapper;
using Bizcom.Application.Abstractions;
using Bizcom.Application.Models.VIewModels;
using Bizcom.Application.UseCases.Teachers.Queries;
using Bizcom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Teachers.QueryHandlers
{
    public class GetAllTeacherQueryHandler : IQueryHandler<GetAllTeacherQuery, List<UserViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllTeacherQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
        {
            List<User> teachers = await (from user in _context.Users
                                         join teacher in _context.Teachers on user.Id equals teacher.UserId
                                         select user)
                                         .ToListAsync(cancellationToken);

            return _mapper.Map<List<UserViewModel>>(teachers);
        }
    }
}
