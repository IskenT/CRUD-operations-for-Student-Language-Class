using LanguageClassManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LanguageClassManager.Data
{
    public class ApplicationDbContext : DbContext
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {     
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<LanguageClass> LanguageClasses { get; set; }
    }
}
