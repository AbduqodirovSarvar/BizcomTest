using AutoMapper;
using Bizcom.Application.Abstractions;
using Bizcom.Application.Models.VIewModels;
using Bizcom.Application.UseCases.Users.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Users.QueryHandlers
{
    public class GetAllUserWithBeelineQueryHandler : IQueryHandler<GetAllUserWithBeelineQuery, AllUsersViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllUserWithBeelineQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<AllUsersViewModel> Handle(GetAllUserWithBeelineQuery request, CancellationToken cancellationToken)
        {
            var users = _context.Users
                .Where(x => x.Phone.Substring(3, 5) == "90" 
                    | x.Phone.Substring(3, 5) == "91");

            var students = users.Where(x => (_context.Students.Any(s => s.UserId == x.Id)))
                                    .ToListAsync(cancellationToken);

            var teachers = users.Where(x => (_context.Teachers.Any(t => t.UserId == x.Id)))
                                    .ToListAsync(cancellationToken);

            AllUsersViewModel viewModel = new AllUsersViewModel();
            viewModel.Teachers = _mapper.Map<List<UserViewModel>>(teachers);
            viewModel.Students = _mapper.Map<List<UserViewModel>>(students);

            return Task.FromResult(viewModel);
        }
    }
}
