using Microsoft.EntityFrameworkCore;
using Multi_lingual_student_management_system.Models;

namespace Multi_lingual_student_management_system.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Localization> Localizations { get; set; }
    }
}
