using Bizcom.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bizcom.Application.UseCases.Teachers.Commands
{
    public class AddStudentScoreCommand : ICommand<bool>
    {
        [Required] public int StudentId { get; set; }
        [Required] public int CourseId { get; set; }
        [Required] public int Score { get; set; }
    }
}
