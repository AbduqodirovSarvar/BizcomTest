using AutoMapper;
using Bizcom.Application.Abstractions;
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
    public class GetTeacherCoursewhichNstudentAndOverMScoreQueryHandler : IQueryHandler<GetTeacherCoursewhichNstudentAndOverMScoreQuery, List<CourseViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetTeacherCoursewhichNstudentAndOverMScoreQueryHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<List<CourseViewModel>> Handle(GetTeacherCoursewhichNstudentAndOverMScoreQuery request, CancellationToken cancellationToken)
        {
            var courses = await _context.CoursesStudents
                                    .Include(x => x.Course).Include(s => s.Student)
                                        .Where(x => x.Student != null 
                                            && x.Student.UserId == _currentUserService.UserId 
                                                && x.Score >= 80)
                                                    .GroupBy(c => c.Course)
                                                        .Where(x => x.Count(sc => sc.Score >= 80) >= 10)
                                                            .Select(x => x.Key).ToListAsync(cancellationToken);

            return _mapper.Map<List<CourseViewModel>>(courses);
        }
    }
}
