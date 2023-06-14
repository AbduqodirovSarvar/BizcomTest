using Bizcom.Application.Abstractions;
using Bizcom.Application.Exceptions;
using Bizcom.Application.UseCases.Authorize.Commands;
using Bizcom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Authorize.CommandHandlers
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly IAppDbContext _context;
        private readonly ITokenService _tokenService;
        public LoginCommandHandler(IAppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users
                                    .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (user == null)
                throw new LoginException();

            if(user.Phone != request.Phone)
                throw new LoginException();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email)
            };

            if (await _context.Teachers.AnyAsync(x => x.UserId == user.Id, cancellationToken))
                claims.Add(new Claim(ClaimTypes.Role, "Teacher"));

            else if(await _context.Students.AnyAsync(x => x.UserId == user.Id, cancellationToken))
                claims.Add(new Claim(ClaimTypes.Role, "Student"));

            return _tokenService.GetAccessToken(claims.ToArray());
        }
    }
}
