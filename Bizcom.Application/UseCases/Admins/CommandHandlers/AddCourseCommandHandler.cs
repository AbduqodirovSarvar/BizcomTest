using AutoMapper;
using Bizcom.Application.Abstractions;
using Bizcom.Application.Exceptions;
using Bizcom.Application.Models.VIewModels;
using Bizcom.Application.UseCases.Admins.Commands;
using Bizcom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Admins.CommandHandlers
{
    public class AddCourseCommandHandler : ICommandHandler<AddCourseCommand, CourseViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public AddCourseCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CourseViewModel> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses
                                    .FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken);
            
            if (course != null)
                throw new AlreadyExistsException("Course");
            
            var teacher = await _context.Teachers
                                    .FirstOrDefaultAsync(x => x.Id == request.TeacherId, cancellationToken);
            
            if(teacher == null)
                throw new NotFoundException("Teacher");

            Course newCourse = new Course();
            newCourse.Name = request.Name;
            newCourse.TeacherId = request.TeacherId;

            await _context.Courses.AddAsync(newCourse, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CourseViewModel>(await _context.Courses
                                    .FirstOrDefaultAsync(x => x.Name == newCourse.Name, cancellationToken));
            throw new NotImplementedException();
        }
    }
}
