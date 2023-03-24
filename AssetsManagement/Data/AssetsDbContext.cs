using Microsoft.EntityFrameworkCore;
using AssetManagment.Models;

namespace AssetManagment.Data
{
    public class AssetsContext : DbContext
    {
        public AssetsContext(DbContextOptions<AssetsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Devices>()
            .HasMany(p => p.Contacts)
            .WithMany(p => p.Devices)
            .UsingEntity<DeviceAssignments>(
                j => j
                    .HasOne(da => da.Contacts)
                    .WithMany(c => c.DeviceAssignments)
                    .HasForeignKey(pt => pt.ContactId),
                j => j
                    .HasOne(da => da.Devices)
                    .WithMany(d => d.DeviceAssignments)
                    .HasForeignKey(da => da.DeviceId),
                j =>
                {
                    j.HasKey(t => new { t.DeviceId, t.ContactId });
                });
        }

        public virtual DbSet<Contacts> Contacts { get; set; }

        public virtual DbSet<DeviceAssignments> DeviceAssignments { get; set; }

        public virtual DbSet<DeviceCategories> DeviceCategories { get; set; }

        public virtual DbSet<DeviceLocations> DeviceLocations { get; set; }

        public virtual DbSet<Devices> Devices { get; set; }

    }
}
