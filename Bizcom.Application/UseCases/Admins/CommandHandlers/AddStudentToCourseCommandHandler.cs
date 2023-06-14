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
    public class AddStudentToCourseCommandHandler : ICommandHandler<AddStudentToCourseCommand, StudentCourseViewModel>
    {
        private readonly IAppDbContext _context;
        public AddStudentToCourseCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<StudentCourseViewModel> Handle(AddStudentToCourseCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                                    .FirstOrDefaultAsync(x => x.Id == request.StudentId, cancellationToken);

            if (student == null)
                throw new NotFoundException("Student");

            var course = await _context.Courses
                                    .FirstOrDefaultAsync(x => x.Id == request.CourseId, cancellationToken);
            
            if (course == null)
                throw new NotFoundException("Course");

            CourseStudent courseStudent = new CourseStudent();
            courseStudent.CourseId = request.CourseId;
            courseStudent.StudentId = request.StudentId;

            await _context.CoursesStudents.AddAsync(courseStudent, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new StudentCourseViewModel()
            {
                Id = course.Id,
                Name = course.Name,
                StudentId = student.Id,
                TeacherId = course.TeacherId
            };
        }
    }
}
