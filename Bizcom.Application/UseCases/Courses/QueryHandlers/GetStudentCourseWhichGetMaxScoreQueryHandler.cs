using AutoMapper;
using Bizcom.Application.Abstractions;
using Bizcom.Application.Exceptions;
using Bizcom.Application.Models.VIewModels;
using Bizcom.Application.UseCases.Courses.Queries;
using Bizcom.Domain.Entities;
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
            Student? student = await _context.Students.Include(x => x.Courses)
                                    .FirstOrDefaultAsync(x => x.UserId == _currentUserService.UserId, cancellationToken);

            if (student == null)
                throw new NotFoundException("Student");

            var courseStudent = await _context.CoursesStudents
                                    .Where(x => x.StudentId == student.Id)
                                            .OrderByDescending(x => x.Score)
                                                    .FirstOrDefaultAsync(cancellationToken);

            if (courseStudent == null)
                throw new NotFoundException("Score");

            Course? foundCourse = await _context.Courses
                                        .FirstOrDefaultAsync(x => x.Id == courseStudent.CourseId, cancellationToken);

            if (foundCourse == null)
                throw new NotFoundException("Course");

            return _mapper.Map<CourseViewModel>(foundCourse);
        }
    }
}
