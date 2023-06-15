using Bizcom.Application.Abstractions;
using Bizcom.Application.Models.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Users.Queries
{
    public class GetAllUserQuery : IQuery<List<UserViewModel>>
    {
        public GetAllUserQuery() { }
    }
}
