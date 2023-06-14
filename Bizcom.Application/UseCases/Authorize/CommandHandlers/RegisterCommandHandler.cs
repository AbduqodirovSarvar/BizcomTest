using AutoMapper;
using Bizcom.Application.Abstractions;
using Bizcom.Application.Exceptions;
using Bizcom.Application.Models.VIewModels;
using Bizcom.Application.UseCases.Authorize.Commands;
using Bizcom.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Authorize.CommandHandlers
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, UserViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public RegisterCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserViewModel> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            bool HasUser = await _context.Users
                                    .AnyAsync(x => x.Email == command.Email 
                                        | x.Phone == command.Phone, cancellationToken);
            
            if (HasUser)
                throw new AlreadyExistsException("User");

            User user = _mapper.Map<User>(command);
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            UserViewModel viewModel = _mapper.Map<UserViewModel>(await _context.Users
                                                .FirstOrDefaultAsync(x => x.Email == user.Email, cancellationToken));
            
            return viewModel;
        }
    }
}
