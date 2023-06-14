using AutoMapper;
using Bizcom.Application.Abstractions;
using Bizcom.Application.Exceptions;
using Bizcom.Application.Models.VIewModels;
using Bizcom.Application.UseCases.Courses.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Courses.QueryHandlers
{
    public class GetStudentCourseWhichGetMaxScoreQueryHandler : IQueryHandler<GetStudentCourseWhichGetMaxScoreQuery, CourseViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public GetStudentCourseWhichGetMaxScoreQueryHandler(IAppDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task<CourseViewModel> Handle(GetStudentCourseWhichGetMaxScoreQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                                    .FirstOrDefaultAsync(x => x.UserId == _currentUserService.UserId, cancellationToken);

            if (student == null)
            {
                throw new NotFoundException("Student");
            }

            var course = _context.CoursesStudents.Where(x => x.StudentId == student.Id).Include(c => c.Course).OrderByDescending(x => x.Score).Select(c => c.Course).First();

            if (course == null)
            {
                throw new NotFoundException("Course");
            }

            return _mapper.Map<CourseViewModel>(course);
        }
    }
}
