using System.ComponentModel.DataAnnotations;

namespace AssetManagment.Models
{
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; }       

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
