using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))] public User? UserStudent { get; set; }
        public int StudentRegNumber { get; set; }
        public ICollection<Course>? Courses { get; set; } = new HashSet<Course>();
    }
}
