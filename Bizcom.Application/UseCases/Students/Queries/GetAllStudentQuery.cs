using Bizcom.Application.Abstractions;
using Bizcom.Application.Models.VIewModels;
using Bizcom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Students.Queries
{
    public class GetAllStudentQuery : IQuery<List<UserViewModel>>
    {
        public GetAllStudentQuery() { }
    }
}
