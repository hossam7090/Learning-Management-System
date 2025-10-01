using Lms.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Infrastructure.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Student> students { get; set; }
        DbSet<Department> departments { get; set; }
        DbSet<Subject> subjects { get; set; }
        DbSet<DepartmetSubject> departmetSubjects {  get; set; }
        DbSet<StudentSubject> studentSubjects { get; set; }
        DbSet<Instructor> instructors { get; set; }
        DbSet<Ins_Subject> ins_Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


    }

}
