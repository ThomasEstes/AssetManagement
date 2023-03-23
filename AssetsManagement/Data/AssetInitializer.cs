using AssetManagment.Models;

namespace AssetManagment.Data
{
    public static class AssetInitializer
    {
        public static void Initialize(AssetsContext context)
        {
            if (context.Devices.Any())
            {
                return;   // DB has been seeded
            }

            var contact = new Contacts[]
            {
                new Contacts{FullName = "John Smith",FirstName="John", LastName="Smith"},
                new Contacts{FullName = "Jane Doe",FirstName="Jane", LastName="Doe"}
            };

            var location = new DeviceLocations[]
            {
                new DeviceLocations{DeviceLocationName="Auction"},
                new DeviceLocations{DeviceLocationName="Closet"},
                new DeviceLocations{DeviceLocationName="Conference"},
                new DeviceLocations{DeviceLocationName="Flex Cube"},
                new DeviceLocations{DeviceLocationName="Flex Office"},
                new DeviceLocations{DeviceLocationName="Huddle"},
                new DeviceLocations{DeviceLocationName="Recycle"},
                new DeviceLocations{DeviceLocationName="Repair"},
                new DeviceLocations{DeviceLocationName="User"}
            };

            context.DeviceLocations.AddRange(location);
            context.SaveChanges();

            var category = new DeviceCategories[]
            {
                new DeviceCategories{DeviceCategoryName="Cable"},
                new DeviceCategories{DeviceCategoryName="Docking Station"},
                new DeviceCategories{DeviceCategoryName="Headset"},
                new DeviceCategories{DeviceCategoryName="Keyboard Mouse"},
                new DeviceCategories{DeviceCategoryName="Laptop"},
                new DeviceCategories{DeviceCategoryName="Monitor"},
                new DeviceCategories{DeviceCategoryName="Power Cord"},
                new DeviceCategories{DeviceCategoryName="Printer"},
                new DeviceCategories{DeviceCategoryName="Video Conf Equip"},
                new DeviceCategories{DeviceCategoryName="Wall Display"},
                new DeviceCategories{DeviceCategoryName="Monitor 2"}
            };

            context.DeviceCategories.AddRange(category);
            context.SaveChanges();


            context.Contacts.AddRange(contact);
            context.SaveChanges();

            var devices = new Devices[]
            {
                new Devices{DeviceCategoryId=5,DeviceLocationId=9,Description="Surface Laptop",SerialNumber="123456789"},
                new Devices{DeviceCategoryId=6,DeviceLocationId=9,Description="View Sonic Monitor",SerialNumber="VS123456789"},
                new Devices{DeviceCategoryId=11,DeviceLocationId=9,Description="View Sonic Monitor",SerialNumber="VS987654321"},
                new Devices{DeviceCategoryId=2,DeviceLocationId=9,Description="SURFACE DOCK 2",SerialNumber="SD987654321"},
                new Devices{DeviceCategoryId=5,DeviceLocationId=9,Description="Surface Laptop",SerialNumber="999888777"},
                new Devices{DeviceCategoryId=6,DeviceLocationId=9,Description="View Sonic Monitor",SerialNumber="VS999888777"},
                new Devices{DeviceCategoryId=11,DeviceLocationId=9,Description="View Sonic Monitor",SerialNumber="VS98798766"},
                new Devices{DeviceCategoryId=2,DeviceLocationId=9,Description="SURFACE DOCK 2",SerialNumber="SD999888777"}
            };
            
            context.Devices.AddRange(devices);
            context.SaveChanges();

            
           

            var assignment = new DeviceAssignments[]
            {
                new DeviceAssignments{DeviceId=1,ContactId=1},
                new DeviceAssignments{DeviceId=2,ContactId=1},
                new DeviceAssignments{DeviceId=3,ContactId=1},
                new DeviceAssignments{DeviceId=4,ContactId=1},
                new DeviceAssignments{DeviceId=5,ContactId=2},
                new DeviceAssignments{DeviceId=6,ContactId=2},
                new DeviceAssignments{DeviceId=7,ContactId=2},
                new DeviceAssignments{DeviceId=8,ContactId=2}
            };

            context.DeviceAssignments.AddRange(assignment);
            context.SaveChanges();
        }
    }
}
