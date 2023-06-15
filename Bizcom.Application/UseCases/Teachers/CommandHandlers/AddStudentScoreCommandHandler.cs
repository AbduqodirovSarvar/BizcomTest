using Bizcom.Application.Abstractions;
using Bizcom.Application.Exceptions;
using Bizcom.Application.UseCases.Courses.Queries;
using Bizcom.Application.UseCases.Teachers.Commands;
using Bizcom.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Teachers.CommandHandlers
{
    public class AddStudentScoreCommandHandler : ICommandHandler<AddStudentScoreCommand, bool>
    {
        private readonly IAppDbContext _context;
        private readonly IMediator _mediator;
        public AddStudentScoreCommandHandler(IAppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AddStudentScoreCommand request, CancellationToken cancellationToken)
        {
            var courses = await _mediator.Send(new GetAllCourseForTeacherQuery(), cancellationToken);

            var course = await _context.Courses.Include(x => x.Students).FirstOrDefaultAsync(x => x.Id == request.CourseId, cancellationToken);
            if (course == null)
                throw new NotFoundException("Course");

            if (!course.Students.Any(x => x.Id == request.StudentId))
                throw new NotFoundException("Student");

            CourseStudent courseStudent = new CourseStudent();
            courseStudent.StudentId = request.StudentId;
            courseStudent.CourseId = request.CourseId;
            courseStudent.Score = request.Score;
            await _context.CoursesStudents.AddAsync(courseStudent, cancellationToken);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
