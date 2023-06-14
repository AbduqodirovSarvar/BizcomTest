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
    public class GetTeachersForStudentsScoreOverNQueryHandler : IQueryHandler<GetTeachersForStudentsScoreOverNQuery, List<UserViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public GetTeachersForStudentsScoreOverNQueryHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<List<UserViewModel>> Handle(GetTeachersForStudentsScoreOverNQuery request, CancellationToken cancellationToken)
        {
            var studentCourseTeachers = _context.Courses
                                            .Where(x => (_context.CoursesStudents.Any(c => c.CourseId == x.Id 
                                                && c.Score >= request.Score 
                                                    && c.StudentId == _currentUserService.UserId)))
                                                        .Include(x => x.Teacher).Select(x => x.Teacher);

            var teachers = await _context.Users
                                .Where(x => studentCourseTeachers.Any(t => t != null && t.UserId == x.Id))
                                    .ToListAsync(cancellationToken);

            return _mapper.Map<List<UserViewModel>>(teachers);
        }
    }
}
