using System.ComponentModel.DataAnnotations;

namespace AssetManagment.Models
{
    public class DeviceLocations
    {
        [Key]
        public int DeviceLocationId { get; set; }

        public string DeviceLocationName { get; set; }

        public virtual ICollection<Devices> Devices { get; } = new List<Devices>();
    }
}
