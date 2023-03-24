using System.ComponentModel.DataAnnotations;

namespace AssetManagment.Models
{
    public class DeviceAssignments
    {
        [Key]
        public int DeviceAssignmentId { get; set; }

        public int DeviceId { get; set; }
        public Devices Devices { get; set; }

        public int ContactId { get; set; }
        public Contacts Contacts { get; set; }

    }
}
