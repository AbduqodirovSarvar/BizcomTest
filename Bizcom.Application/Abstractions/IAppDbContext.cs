using Bizcom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.Abstractions
{
    public interface IAppDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CoursesStudents { get; set; }
        public DbSet<Admin> Admins { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
