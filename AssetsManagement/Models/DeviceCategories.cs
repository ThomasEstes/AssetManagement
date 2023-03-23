using System.ComponentModel.DataAnnotations;

namespace AssetManagment.Models
{
    public class DeviceCategories
    {
        [Key]
        public int DeviceCategoryId { get; set; }

        public string DeviceCategoryName { get; set; }

        public virtual ICollection<Devices> Devices { get; } = new List<Devices>();

    }
}
