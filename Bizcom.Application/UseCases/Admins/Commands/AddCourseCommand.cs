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
    public class AddCourseCommand : ICommand<CourseViewModel>
    {
        [Required] public string Name { get; set; } = string.Empty;
        [Required] public int TeacherId { get; set; }
    }
}
