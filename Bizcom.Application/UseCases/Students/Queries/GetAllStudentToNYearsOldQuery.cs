﻿using Bizcom.Application.Abstractions;
using Bizcom.Application.Models.VIewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.UseCases.Students.Queries
{
    public class GetAllStudentToNYearsOldQuery : IQuery<List<UserViewModel>>
    {
        [Required] public int Age { get; set; }
    }
}
