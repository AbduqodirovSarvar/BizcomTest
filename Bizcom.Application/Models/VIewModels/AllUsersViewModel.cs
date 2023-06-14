using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.Models.VIewModels
{
    public class AllUsersViewModel
    {
        public List<UserViewModel> Teachers { get; set; } = new List<UserViewModel>();
        public List<UserViewModel> Students { get;set; } = new List<UserViewModel>();
    }
}
