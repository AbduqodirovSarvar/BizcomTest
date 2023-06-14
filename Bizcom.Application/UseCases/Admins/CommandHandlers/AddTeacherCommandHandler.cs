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
    public class AddTeacherCommandHandler : ICommandHandler<AddTeacherCommand, bool>
    {
        private readonly IAppDbContext _context;
        public AddTeacherCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("User");
            }

            Teacher teacher = new Teacher();
            teacher.UserId = user.Id;
            await _context.Teachers.AddAsync(teacher, cancellationToken);

            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
