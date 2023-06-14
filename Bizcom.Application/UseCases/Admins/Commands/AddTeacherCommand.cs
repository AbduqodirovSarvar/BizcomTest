using Bizcom.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bizcom.Application.UseCases.Admins.Commands
{
    public class AddTeacherCommand : ICommand<bool>
    {
        [Required] public int UserId { get; set; }
    }
}
