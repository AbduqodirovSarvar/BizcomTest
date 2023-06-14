using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Domain.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")] public User? UserAdmin { get; set; }
    }
}
