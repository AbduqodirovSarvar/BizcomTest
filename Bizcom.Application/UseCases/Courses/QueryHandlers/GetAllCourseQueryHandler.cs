using AutoMapper;
using Bizcom.Application.Abstractions;
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
    public class GetAllCourseQueryHandler : IQueryHandler<GetAllCourseQuery, List<CourseViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllCourseQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CourseViewModel>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            List<Course> courses = await _context.Courses
                                            .ToListAsync(cancellationToken);

            return _mapper.Map<List<CourseViewModel>>(courses);
        }
    }
}
