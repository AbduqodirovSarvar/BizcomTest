using Bizcom.Application.Abstractions;
using Bizcom.Application.Models.VIewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Students.Queries
{
    public class GetAllStudentsByNameContainQuery : IQuery<List<UserViewModel>>
    {
        [Required] public string Name { get; set; } = string.Empty;
    }
}
