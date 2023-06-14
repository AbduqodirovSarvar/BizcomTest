using Bizcom.Application.Abstractions;
using Bizcom.Application.Models.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Students.Queries
{
    public class GetAllStudentsFromDateToDateQuery : IQuery<List<UserViewModel>>
    {
        public GetAllStudentsFromDateToDateQuery() { }
    }
}
