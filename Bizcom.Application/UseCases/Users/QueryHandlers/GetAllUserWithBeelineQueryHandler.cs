using AutoMapper;
using Bizcom.Application.Abstractions;
using Bizcom.Application.Models.VIewModels;
using Bizcom.Application.UseCases.Users.Queries;
using Bizcom.Domain.Entities;
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
        public async Task<AllUsersViewModel> Handle(GetAllUserWithBeelineQuery request, CancellationToken cancellationToken)
        {
            var users = _context.Users
                            .Where(x => x.Phone.Substring(4, 2) == "90"
                                | x.Phone.Substring(4, 2) == "91");

            List<User> students = await (from user in _context.Users
                                            join student in _context.Students on user.Id equals student.UserId
                                                select user)
                                         .ToListAsync(cancellationToken);

            List<User> teachers = await (from user in _context.Users
                                         join teacher in _context.Teachers on user.Id equals teacher.UserId
                                         select user)
                                         .ToListAsync(cancellationToken);

            AllUsersViewModel viewModel = new AllUsersViewModel();
            viewModel.Teachers.AddRange(_mapper.Map<List<UserViewModel>>(teachers));
            viewModel.Students.AddRange(_mapper.Map<List<UserViewModel>>(students));

            return viewModel;
        }
    }
}
