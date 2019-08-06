
using Microsoft.EntityFrameworkCore;
using TestingonCore.Models;

namespace Repository.core
{
    public class StudentdbContext : DbContext
    {
        public StudentdbContext(DbContextOptions<StudentdbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
         public DbSet<Subject> Subjects { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(a => a.Subjects)
                .WithOne(b => b.Student)
                .HasForeignKey<Subject>(b => b.stud_id);
        }*/

    }
}
