using Microsoft.EntityFrameworkCore;
using AssetManagment.Models;

namespace AssetManagment.Data
{
    public class AssetsContext : DbContext
    {
        public AssetsContext(DbContextOptions<AssetsContext> options) : base(options)
        {
        }

        public virtual DbSet<Contacts> Contacts { get; set; }

        public virtual DbSet<DeviceAssignments> DeviceAssignments { get; set; }

        public virtual DbSet<DeviceCategories> DeviceCategories { get; set; }

        public virtual DbSet<DeviceLocations> DeviceLocations { get; set; }

        public virtual DbSet<Devices> Devices { get; set; }

    }
}
