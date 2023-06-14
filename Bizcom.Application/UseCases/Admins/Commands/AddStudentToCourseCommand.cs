using Bizcom.Application.Abstractions;
using Bizcom.Application.Models.VIewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bizcom.Application.UseCases.Admins.Commands
{
    public class AddStudentToCourseCommand : ICommand<StudentCourseViewModel>
    {
        [Required] public int StudentId { get; set; }
        [Required] public int CourseId { get; set; }
    }
}
