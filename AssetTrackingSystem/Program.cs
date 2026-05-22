
using AssetTrackingSystem.Data;
using AssetTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;

AppDbContext context = new AppDbContext();

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("ASSET TRACKING SYSTEM");
    Console.WriteLine("-------------------------");

    Console.WriteLine("1 - Show Computer Assets");
    Console.WriteLine("2 - Show Mobile Assets");

    Console.WriteLine("3 - Add Computer Asset");
    Console.WriteLine("4 - Add Mobile Asset");

    Console.WriteLine("5 - Update Computer Brand");
    Console.WriteLine("6 - Delete Computer");

    Console.WriteLine("0 - Exit");

    Console.WriteLine();
    Console.Write("Select option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":

            Console.WriteLine();
            Console.WriteLine("COMPUTER ASSETS");
            Console.WriteLine("-------------------------");

            var computers = context.ComputerAssets
                .Include(x => x.Office)
                .ToList();

            foreach (var computer in computers)
            {
                Console.WriteLine(
                    $"Brand: {computer.Brand} | " +
                    $"Model: {computer.ModelName} | " +
                    $"Office: {computer.Office.OfficeName}"
                );
            }

            break;


        case "2":

            Console.WriteLine();
            Console.WriteLine("MOBILE ASSETS");
            Console.WriteLine("-------------------------");

            var mobiles = context.MobileAssets
                .Include(x => x.Office)
                .ToList();

            foreach (var mobile in mobiles)
            {
                Console.WriteLine(
                    $"Brand: {mobile.Brand} | " +
                    $"Model: {mobile.ModelName} | " +
                    $"Office: {mobile.Office.OfficeName}"
                );
            }

            break;

        case "3":

            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();

            Console.Write("Enter Model: ");
            string model = Console.ReadLine();

            Console.Write("Enter Computer Type: ");
            string type = Console.ReadLine();

            ComputerAsset newComputer = new ComputerAsset()
            {
                Brand = brand,
                ModelName = model,
                ComputerType = type,

                PurchaseDate = DateTime.Now,
                PurchasePriceUsd = 1000,
                LocalPrice = 1000,

                SerialNumber = Guid.NewGuid().ToString(),

                EmployeeUserName = "newuser",

                WarrantyExpirationDate = DateTime.Now.AddYears(3),

                OfficeId = 1
            };

            context.ComputerAssets.Add(newComputer);

            context.SaveChanges();

            Console.WriteLine("Computer added successfully!");

            break;

        case "5":

            Console.Write("Enter Computer Id: ");

            int updateId = int.Parse(Console.ReadLine());

            var computerToUpdate = context.ComputerAssets
                .FirstOrDefault(x => x.Id == updateId);

            if (computerToUpdate != null)
            {
                Console.Write("Enter New Brand: ");

                computerToUpdate.Brand = Console.ReadLine();

                context.SaveChanges();

                Console.WriteLine("Computer updated!");
            }
            else
            {
                Console.WriteLine("Computer not found!");
            }

            break;


        case "6":

            Console.Write("Enter Computer Id: ");

            int deleteId = int.Parse(Console.ReadLine());

            var computerToDelete = context.ComputerAssets
                .FirstOrDefault(x => x.Id == deleteId);

            if (computerToDelete != null)
            {
                context.ComputerAssets.Remove(computerToDelete);

                context.SaveChanges();

                Console.WriteLine("Computer deleted!");
            }
            else
            {
                Console.WriteLine("Computer not found!");
            }

            break;

        case "0":

            running = false;
            break;


        default:

            Console.WriteLine("Invalid option!");
            break;
    }
}




//using AssetTrackingSystem.Data;
//using AssetTrackingSystem.Models;
//using Microsoft.EntityFrameworkCore;

//AppDbContext context = new AppDbContext();

//if (!context.Offices.Any())
//{
//    Office swedenOffice = new Office()
//    {
//        OfficeName = "Sweden Office",
//        Country = "Sweden",
//        Currency = "SEK"
//    };

//    Office usaOffice = new Office()
//    {
//        OfficeName = "USA Office",
//        Country = "USA",
//        Currency = "USD"
//    };

//    Office germanyOffice = new Office()
//    {
//        OfficeName = "Germany Office",
//        Country = "Germany",
//        Currency = "EUR"
//    };

//    context.Offices.AddRange(swedenOffice, usaOffice, germanyOffice);
//    context.SaveChanges();

//    List<ComputerAsset> computers = new List<ComputerAsset>()
//    {
//        new ComputerAsset()
//        {
//            ComputerType = "Laptop",
//            Brand = "Lenovo",
//            ModelName = "ThinkPad X1",
//            PurchaseDate = new DateTime(2024, 2, 11),
//            PurchasePriceUsd = 1200,
//            LocalPrice = 13200,
//            SerialNumber = "LEN-X1-001",
//            EmployeeUserName = "basem",
//            WarrantyExpirationDate = new DateTime(2027, 2, 11),
//            OfficeId = swedenOffice.Id
//        },

//        new ComputerAsset()
//        {
//            ComputerType = "Desktop",
//            Brand = "Dell",
//            ModelName = "OptiPlex 7090",
//            PurchaseDate = new DateTime(2023, 6, 5),
//            PurchasePriceUsd = 900,
//            LocalPrice = 900,
//            SerialNumber = "DEL-OP-002",
//            EmployeeUserName = "john",
//            WarrantyExpirationDate = new DateTime(2026, 6, 5),
//            OfficeId = usaOffice.Id
//        },

//        new ComputerAsset()
//        {
//            ComputerType = "Laptop",
//            Brand = "HP",
//            ModelName = "EliteBook 840",
//            PurchaseDate = new DateTime(2022, 12, 1),
//            PurchasePriceUsd = 1000,
//            LocalPrice = 920,
//            SerialNumber = "HP-EL-003",
//            EmployeeUserName = "anna",
//            WarrantyExpirationDate = new DateTime(2025, 12, 1),
//            OfficeId = germanyOffice.Id
//        }
//    };

//    List<MobileAsset> mobiles = new List<MobileAsset>()
//    {
//        new MobileAsset()
//        {
//            MobileType = "iPhone",
//            Brand = "Apple",
//            ModelName = "iPhone 15",
//            PurchaseDate = new DateTime(2025, 1, 10),
//            PurchasePriceUsd = 999,
//            LocalPrice = 999,
//            SerialNumber = "APL-IP15-001",
//            EmployeeUserName = "ahmad",
//            WarrantyExpirationDate = new DateTime(2028, 1, 10),
//            OfficeId = usaOffice.Id
//        },

//        new MobileAsset()
//        {
//            MobileType = "Samsung",
//            Brand = "Samsung",
//            ModelName = "Galaxy S24",
//            PurchaseDate = new DateTime(2024, 8, 20),
//            PurchasePriceUsd = 850,
//            LocalPrice = 9350,
//            SerialNumber = "SAM-S24-002",
//            EmployeeUserName = "sara",
//            WarrantyExpirationDate = new DateTime(2027, 8, 20),
//            OfficeId = swedenOffice.Id
//        },

//        new MobileAsset()
//        {
//            MobileType = "Tablet",
//            Brand = "Apple",
//            ModelName = "iPad Air",
//            PurchaseDate = new DateTime(2023, 4, 15),
//            PurchasePriceUsd = 650,
//            LocalPrice = 598,
//            SerialNumber = "APL-IPAD-003",
//            EmployeeUserName = "maria",
//            WarrantyExpirationDate = new DateTime(2026, 4, 15),
//            OfficeId = germanyOffice.Id
//        }
//    };

//    context.ComputerAssets.AddRange(computers);
//    context.MobileAssets.AddRange(mobiles);
//    context.SaveChanges();

//    Console.WriteLine("Seed data saved successfully!");
//}


//else
//{
//    Console.WriteLine("Data already exists. No new data added.");
//}

//// DISPLAY COMPUTER ASSETS
//Console.WriteLine("COMPUTER ASSETS");
//Console.WriteLine("-------------------------");

//List<ComputerAsset> computersData =
//    context.ComputerAssets
//    .Include(c => c.Office)
//    .ToList();

//foreach (ComputerAsset computer in computersData)
//{
//    Console.WriteLine(
//        $"Id: {computer.Id} | " +
//        $"Brand: {computer.Brand} | " +
//        $"Model: {computer.ModelName} | " +
//        $"Office: {computer.Office.OfficeName} | " +
//        $"User: {computer.EmployeeUserName} | " +
//        $"Status: {GetAssetStatus(computer.WarrantyExpirationDate)}"
//    );
//}

//// UPDATE COMPUTER
//var computerToUpdate = context.ComputerAssets
//    .FirstOrDefault(x => x.Id == 1);

//if (computerToUpdate != null)
//{
//    computerToUpdate.Brand = "ASUS";

//    context.SaveChanges();

//    Console.WriteLine("Computer updated successfully!");
//}


//// DELETE COMPUTER
//var computerToDelete = context.ComputerAssets
//    .FirstOrDefault(x => x.Id == 3);

//if (computerToDelete != null)
//{
//    context.ComputerAssets.Remove(computerToDelete);

//    context.SaveChanges();

//    Console.WriteLine("Computer deleted successfully!");
//}

//// FILTER LAPTOPS
//Console.WriteLine();
//Console.WriteLine("LAPTOPS ONLY");
//Console.WriteLine("-------------------------");

//var laptops = context.ComputerAssets
//    .Where(x => x.ComputerType == "Laptop")
//    .Include(x => x.Office)
//    .ToList();

//foreach (var laptop in laptops)
//{
//    Console.WriteLine(
//        $"Brand: {laptop.Brand} | " +
//        $"Model: {laptop.ModelName} | " +
//        $"Office: {laptop.Office.OfficeName}"
//    );
//}


//// SORT BY PURCHASE DATE
//Console.WriteLine();
//Console.WriteLine("SORTED BY PURCHASE DATE");
//Console.WriteLine("-------------------------");

//var sortedComputers = context.ComputerAssets
//    .OrderBy(x => x.PurchaseDate)
//    .ToList();

//foreach (var computer in sortedComputers)
//{
//    Console.WriteLine(
//        $"Brand: {computer.Brand} | " +
//        $"Purchase Date: {computer.PurchaseDate.ToShortDateString()}"
//    );
//}

//// MOBILE ASSETS
//Console.WriteLine();
//Console.WriteLine("MOBILE ASSETS");
//Console.WriteLine("-------------------------");

//var mobilesData = context.MobileAssets
//    .Include(x => x.Office)
//    .ToList();

//foreach (var mobile in mobilesData)
//{
//    Console.WriteLine(
//        $"Brand: {mobile.Brand} | " +
//        $"Model: {mobile.ModelName} | " +
//        $"Type: {mobile.MobileType} | " +
//        $"Office: {mobile.Office.OfficeName} | " +
//        $"User: {mobile.EmployeeUserName}"
//    );
//}


//// ADD MORE COMPUTER ASSETS
////context.ComputerAssets.AddRange(

////    new ComputerAsset()
////    {
////        ComputerType = "Laptop",
////        Brand = "Apple",
////        ModelName = "MacBook Pro",
////        PurchaseDate = new DateTime(2025, 3, 10),
////        PurchasePriceUsd = 2400,
////        LocalPrice = 26400,
////        SerialNumber = "APL-MBP-004",
////        EmployeeUserName = "alex",
////        WarrantyExpirationDate = new DateTime(2028, 3, 10),
////        OfficeId = 1
////    },

////    new ComputerAsset()
////    {
////        ComputerType = "Desktop",
////        Brand = "Lenovo",
////        ModelName = "ThinkCentre",
////        PurchaseDate = new DateTime(2021, 5, 1),
////        PurchasePriceUsd = 700,
////        LocalPrice = 700,
////        SerialNumber = "LEN-TC-005",
////        EmployeeUserName = "david",
////        WarrantyExpirationDate = new DateTime(2024, 5, 1),
////        OfficeId = 2
////    }

////);


////// ADD MORE MOBILE ASSETS
////context.MobileAssets.AddRange(

////    new MobileAsset()
////    {
////        MobileType = "Samsung",
////        Brand = "Samsung",
////        ModelName = "Galaxy Fold",
////        PurchaseDate = new DateTime(2025, 2, 5),
////        PurchasePriceUsd = 1800,
////        LocalPrice = 19800,
////        SerialNumber = "SAM-FOLD-004",
////        EmployeeUserName = "emma",
////        WarrantyExpirationDate = new DateTime(2028, 2, 5),
////        OfficeId = 1
////    },

////    new MobileAsset()
////    {
////        MobileType = "iPhone",
////        Brand = "Apple",
////        ModelName = "iPhone 14",
////        PurchaseDate = new DateTime(2022, 9, 12),
////        PurchasePriceUsd = 850,
////        LocalPrice = 850,
////        SerialNumber = "APL-IP14-005",
////        EmployeeUserName = "oliver",
////        WarrantyExpirationDate = new DateTime(2025, 9, 12),
////        OfficeId = 3
////    }

////);

////context.ComputerAssets.AddRange(

////    new ComputerAsset()
////    {
////        ComputerType = "Laptop",
////        Brand = "Apple",
////        ModelName = "MacBook Pro M3",
////        PurchaseDate = new DateTime(2025, 1, 10),
////        PurchasePriceUsd = 2500,
////        LocalPrice = 27500,
////        SerialNumber = "APL-MBP-101",
////        EmployeeUserName = "alex",
////        WarrantyExpirationDate = new DateTime(2028, 1, 10),
////        OfficeId = 1
////    },

////    new ComputerAsset()
////    {
////        ComputerType = "Laptop",
////        Brand = "ASUS",
////        ModelName = "ZenBook 14",
////        PurchaseDate = new DateTime(2023, 9, 1),
////        PurchasePriceUsd = 1300,
////        LocalPrice = 14300,
////        SerialNumber = "ASUS-ZB-102",
////        EmployeeUserName = "simon",
////        WarrantyExpirationDate = new DateTime(2026, 9, 1),
////        OfficeId = 1
////    },

////    new ComputerAsset()
////    {
////        ComputerType = "Desktop",
////        Brand = "Dell",
////        ModelName = "Precision 3660",
////        PurchaseDate = new DateTime(2022, 4, 20),
////        PurchasePriceUsd = 1700,
////        LocalPrice = 1700,
////        SerialNumber = "DEL-PR-103",
////        EmployeeUserName = "john",
////        WarrantyExpirationDate = new DateTime(2025, 4, 20),
////        OfficeId = 2
////    },

////    new ComputerAsset()
////    {
////        ComputerType = "Desktop",
////        Brand = "HP",
////        ModelName = "ProDesk 600",
////        PurchaseDate = new DateTime(2021, 11, 11),
////        PurchasePriceUsd = 850,
////        LocalPrice = 850,
////        SerialNumber = "HP-PD-104",
////        EmployeeUserName = "anna",
////        WarrantyExpirationDate = new DateTime(2024, 11, 11),
////        OfficeId = 3
////    },

////    new ComputerAsset()
////    {
////        ComputerType = "Laptop",
////        Brand = "Lenovo",
////        ModelName = "ThinkPad T14",
////        PurchaseDate = new DateTime(2024, 3, 15),
////        PurchasePriceUsd = 1500,
////        LocalPrice = 16500,
////        SerialNumber = "LEN-T14-105",
////        EmployeeUserName = "maria",
////        WarrantyExpirationDate = new DateTime(2027, 3, 15),
////        OfficeId = 1
////    }

////);

////context.MobileAssets.AddRange(

////    new MobileAsset()
////    {
////        MobileType = "iPhone",
////        Brand = "Apple",
////        ModelName = "iPhone 16 Pro",
////        PurchaseDate = new DateTime(2025, 2, 1),
////        PurchasePriceUsd = 1400,
////        LocalPrice = 1400,
////        SerialNumber = "APL-IP16-201",
////        EmployeeUserName = "oliver",
////        WarrantyExpirationDate = new DateTime(2028, 2, 1),
////        OfficeId = 2
////    },

////    new MobileAsset()
////    {
////        MobileType = "Samsung",
////        Brand = "Samsung",
////        ModelName = "Galaxy S25 Ultra",
////        PurchaseDate = new DateTime(2025, 1, 20),
////        PurchasePriceUsd = 1350,
////        LocalPrice = 14850,
////        SerialNumber = "SAM-S25-202",
////        EmployeeUserName = "emma",
////        WarrantyExpirationDate = new DateTime(2028, 1, 20),
////        OfficeId = 1
////    },

////    new MobileAsset()
////    {
////        MobileType = "Tablet",
////        Brand = "Microsoft",
////        ModelName = "Surface Pro 10",
////        PurchaseDate = new DateTime(2024, 6, 5),
////        PurchasePriceUsd = 1100,
////        LocalPrice = 12100,
////        SerialNumber = "MS-SP10-203",
////        EmployeeUserName = "lucas",
////        WarrantyExpirationDate = new DateTime(2027, 6, 5),
////        OfficeId = 1
////    },

////    new MobileAsset()
////    {
////        MobileType = "Samsung",
////        Brand = "Samsung",
////        ModelName = "Galaxy A55",
////        PurchaseDate = new DateTime(2023, 5, 17),
////        PurchasePriceUsd = 500,
////        LocalPrice = 5500,
////        SerialNumber = "SAM-A55-204",
////        EmployeeUserName = "david",
////        WarrantyExpirationDate = new DateTime(2026, 5, 17),
////        OfficeId = 3
////    },

////    new MobileAsset()
////    {
////        MobileType = "iPhone",
////        Brand = "Apple",
////        ModelName = "iPhone 13",
////        PurchaseDate = new DateTime(2022, 10, 10),
////        PurchasePriceUsd = 750,
////        LocalPrice = 750,
////        SerialNumber = "APL-IP13-205",
////        EmployeeUserName = "sara",
////        WarrantyExpirationDate = new DateTime(2025, 10, 10),
////        OfficeId = 2
////    }

////);

////context.SaveChanges();

////Console.WriteLine("Large asset dataset added successfully!");





//static string GetAssetStatus(DateTime warrantyExpirationDate)
//{
//    int remainingDays = (warrantyExpirationDate - DateTime.Now).Days;

//    if (remainingDays < 90)
//    {
//        return "YELLOW";
//    }
//    else if (remainingDays < 180)
//    {
//        return "RED";
//    }
//    else
//    {
//        return "NORMAL";
//    }
//}
