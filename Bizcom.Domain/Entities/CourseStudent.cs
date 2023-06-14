using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Domain.Entities
{
    public class CourseStudent
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))] public Student? Student { get; set; }
        public int CourseId { get; set; }
        [ForeignKey(nameof(StudentId))] public Course? Course { get; set; }
        public int Score { get; set; }
    }
}
