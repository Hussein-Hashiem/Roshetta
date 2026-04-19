using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace Roshetta.DAL.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> Users { get; set; } 
        public DbSet<Patient> Patients { get; set; } 
        public DbSet<Doctor> Doctors { get; set; } 
        public DbSet<MedicalRecord> MedicalRecords { get; set; } 
        public DbSet<Visit> Visits { get; set; } 
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; } 
        public DbSet<Department> Departments { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Visit>()
            .HasOne(v => v.Patient)
            .WithMany(p => p.Visits)
            .HasForeignKey(v => v.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}