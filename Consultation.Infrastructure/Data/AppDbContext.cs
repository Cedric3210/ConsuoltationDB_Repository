using Consultation.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext() : base()
        {
        }
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection string of the Azure: 
            // Server=tcp:consultationserver.database.windows.net,1433;Initial Catalog=ConsultationDatabase;Persist Security Info=False;Users ID=ConsultationDB;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;


            optionsBuilder.UseSqlServer("Server=tcp:consultationserver.database.windows.net,1433;" +
                "Initial Catalog=ConsultationDatabaseTesting;Persist Security Info=False;" +
                "User ID=ConsultationDB;Password=ServerAdmin123;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;Connection Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }
  
        public DbSet<ActionLog> ActionLog { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Bulletin> Bulletin { get; set; }
        public DbSet<ConsultationRequest> ConsultationRequest { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<EnrolledCourse> EnrolledCourse { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Program> Program { get; set; }
        public DbSet<SchoolYear> SchoolYear { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
