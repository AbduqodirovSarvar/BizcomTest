using Bizcom.Application.Abstractions;
using Bizcom.Application.Exceptions;
using Bizcom.Application.UseCases.Teachers.Commands;
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
        public AddStudentScoreCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddStudentScoreCommand request, CancellationToken cancellationToken)
        {
            var courseStudent = await _context.CoursesStudents
                                            .FirstOrDefaultAsync(x => x.CourseId == request.CourseId 
                                                && x.StudentId == request.StudentId, cancellationToken);

            if (courseStudent == null)
                throw new NotFoundException("Course and Student");

            courseStudent.Score = request.Score;
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
