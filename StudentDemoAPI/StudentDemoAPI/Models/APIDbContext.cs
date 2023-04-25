using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Models;

namespace StudentDemoAPI.Models
{
    public class APIDbContext: DbContext
    {
        public APIDbContext(DbContextOptions options): base(options) 
        {
        
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
    }
}