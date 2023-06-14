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
    public class GetStudentCourseWhichAverageScoreMaxQueryHandler : IQueryHandler<GetStudentCourseWhichAverageScoreMaxQuery, CourseViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetStudentCourseWhichAverageScoreMaxQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CourseViewModel> Handle(GetStudentCourseWhichAverageScoreMaxQuery request, CancellationToken cancellationToken)
        {
            
            var course = _context.CoursesStudents
                                .Include(c => c.Course)
                                    .GroupBy(x => x.Course)
                                        .OrderByDescending(x => x.Average(s => s.Score))
                                            .Select(x => x.Key)
                                                .FirstOrDefaultAsync(cancellationToken);

            if (course == null)
                throw new NotFoundException("Course");

            return Task.FromResult(_mapper.Map<CourseViewModel>(course));
        }
    }
}
