using System.ComponentModel.DataAnnotations;

namespace AssetManagment.Models
{
    public class Devices
    {
        [Key]
        public int DeviceId { get; set; }

        public int DeviceCategoryId { get; set; }

        public int? DeviceLocationId { get; set; }

        public string Description { get; set; }

        public string SerialNumber { get; set; }

        public virtual DeviceCategories DeviceCategory { get; set; }

        public virtual DeviceLocations DeviceLocation { get; set; }

        public int? ContactId { get; set; }
        public ICollection<Contacts> Contacts { get; set; }
        public List<DeviceAssignments> DeviceAssignments { get; set; }


    }
}
