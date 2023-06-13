using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")] public Teacher? Teacher { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
