using Bizcom.Application.Abstractions;
using Bizcom.Application.Exceptions;
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
    public class AddStudentCommandHandler : ICommandHandler<AddStudentCommand, bool>
    {
        private readonly IAppDbContext _context;
        public AddStudentCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                                .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
            
            if (user == null)
                throw new NotFoundException("User");

            Student student = new Student();
            student.UserId = user.Id;

            await _context.Students.AddAsync(student, cancellationToken);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
