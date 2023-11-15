using ClinicSystemWebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystemWebAPI.Data
{
    public class ClinicWebDbContext : DbContext
    {
        public ClinicWebDbContext(DbContextOptions<ClinicWebDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Appointment>()
                 .HasOne(a => a.Patient)
                 .WithMany(p => p.Appoinments)
                 .HasForeignKey(a => a.PatientId);

        }
    }
}
