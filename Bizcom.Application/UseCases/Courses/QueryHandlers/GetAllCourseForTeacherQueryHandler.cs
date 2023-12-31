﻿using AutoMapper;
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
    public class GetAllCourseForTeacherQueryHandler : IQueryHandler<GetAllCourseForTeacherQuery, List<CourseViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public GetAllCourseForTeacherQueryHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<List<CourseViewModel>> Handle(GetAllCourseForTeacherQuery request, CancellationToken cancellationToken)
        {
            Teacher? teacher = await _context.Teachers
                                        .FirstOrDefaultAsync(x => x.UserId == _currentUserService.UserId, cancellationToken);
            
            if (teacher == null)
                throw new NotFoundException("Teacher");

            int teacherId = teacher.Id;
            List<Course> courses = await _context.Courses
                                            .Where(x => x.TeacherId == teacherId)
                                                .ToListAsync(cancellationToken);

            return _mapper.Map<List<CourseViewModel>>(courses);
        }
    }
}
