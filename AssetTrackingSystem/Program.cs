using AssetTrackingSystem.Data;
using AssetTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;

AppDbContext context = new AppDbContext();

if (!context.Offices.Any())
{
    Office swedenOffice = new Office()
    {
        OfficeName = "Sweden Office",
        Country = "Sweden",
        Currency = "SEK"
    };

    Office usaOffice = new Office()
    {
        OfficeName = "USA Office",
        Country = "USA",
        Currency = "USD"
    };

    Office germanyOffice = new Office()
    {
        OfficeName = "Germany Office",
        Country = "Germany",
        Currency = "EUR"
    };

    context.Offices.AddRange(swedenOffice, usaOffice, germanyOffice);
    context.SaveChanges();

    List<ComputerAsset> computers = new List<ComputerAsset>()
    {
        new ComputerAsset()
        {
            ComputerType = "Laptop",
            Brand = "Lenovo",
            ModelName = "ThinkPad X1",
            PurchaseDate = new DateTime(2024, 2, 11),
            PurchasePriceUsd = 1200,
            LocalPrice = 13200,
            SerialNumber = "LEN-X1-001",
            EmployeeUserName = "basem",
            WarrantyExpirationDate = new DateTime(2027, 2, 11),
            OfficeId = swedenOffice.Id
        },

        new ComputerAsset()
        {
            ComputerType = "Desktop",
            Brand = "Dell",
            ModelName = "OptiPlex 7090",
            PurchaseDate = new DateTime(2023, 6, 5),
            PurchasePriceUsd = 900,
            LocalPrice = 900,
            SerialNumber = "DEL-OP-002",
            EmployeeUserName = "john",
            WarrantyExpirationDate = new DateTime(2026, 6, 5),
            OfficeId = usaOffice.Id
        },

        new ComputerAsset()
        {
            ComputerType = "Laptop",
            Brand = "HP",
            ModelName = "EliteBook 840",
            PurchaseDate = new DateTime(2022, 12, 1),
            PurchasePriceUsd = 1000,
            LocalPrice = 920,
            SerialNumber = "HP-EL-003",
            EmployeeUserName = "anna",
            WarrantyExpirationDate = new DateTime(2025, 12, 1),
            OfficeId = germanyOffice.Id
        }
    };

    List<MobileAsset> mobiles = new List<MobileAsset>()
    {
        new MobileAsset()
        {
            MobileType = "iPhone",
            Brand = "Apple",
            ModelName = "iPhone 15",
            PurchaseDate = new DateTime(2025, 1, 10),
            PurchasePriceUsd = 999,
            LocalPrice = 999,
            SerialNumber = "APL-IP15-001",
            EmployeeUserName = "ahmad",
            WarrantyExpirationDate = new DateTime(2028, 1, 10),
            OfficeId = usaOffice.Id
        },

        new MobileAsset()
        {
            MobileType = "Samsung",
            Brand = "Samsung",
            ModelName = "Galaxy S24",
            PurchaseDate = new DateTime(2024, 8, 20),
            PurchasePriceUsd = 850,
            LocalPrice = 9350,
            SerialNumber = "SAM-S24-002",
            EmployeeUserName = "sara",
            WarrantyExpirationDate = new DateTime(2027, 8, 20),
            OfficeId = swedenOffice.Id
        },

        new MobileAsset()
        {
            MobileType = "Tablet",
            Brand = "Apple",
            ModelName = "iPad Air",
            PurchaseDate = new DateTime(2023, 4, 15),
            PurchasePriceUsd = 650,
            LocalPrice = 598,
            SerialNumber = "APL-IPAD-003",
            EmployeeUserName = "maria",
            WarrantyExpirationDate = new DateTime(2026, 4, 15),
            OfficeId = germanyOffice.Id
        }
    };

    context.ComputerAssets.AddRange(computers);
    context.MobileAssets.AddRange(mobiles);
    context.SaveChanges();

    Console.WriteLine("Seed data saved successfully!");
}


else
{
    Console.WriteLine("Data already exists. No new data added.");
}

// DISPLAY COMPUTER ASSETS
Console.WriteLine("COMPUTER ASSETS");
Console.WriteLine("-------------------------");

List<ComputerAsset> computersData =
    context.ComputerAssets
    .Include(c => c.Office)
    .ToList();

foreach (ComputerAsset computer in computersData)
{
    Console.WriteLine(
        $"Id: {computer.Id} | " +
        $"Brand: {computer.Brand} | " +
        $"Model: {computer.ModelName} | " +
        $"Office: {computer.Office.OfficeName} | " +
        $"User: {computer.EmployeeUserName} | " +
        $"Status: {GetAssetStatus(computer.WarrantyExpirationDate)}"
    );
}

// UPDATE COMPUTER
var computerToUpdate = context.ComputerAssets
    .FirstOrDefault(x => x.Id == 1);

if (computerToUpdate != null)
{
    computerToUpdate.Brand = "ASUS";

    context.SaveChanges();

    Console.WriteLine("Computer updated successfully!");
}


// DELETE COMPUTER
var computerToDelete = context.ComputerAssets
    .FirstOrDefault(x => x.Id == 3);

if (computerToDelete != null)
{
    context.ComputerAssets.Remove(computerToDelete);

    context.SaveChanges();

    Console.WriteLine("Computer deleted successfully!");
}

// FILTER LAPTOPS
Console.WriteLine();
Console.WriteLine("LAPTOPS ONLY");
Console.WriteLine("-------------------------");

var laptops = context.ComputerAssets
    .Where(x => x.ComputerType == "Laptop")
    .Include(x => x.Office)
    .ToList();

foreach (var laptop in laptops)
{
    Console.WriteLine(
        $"Brand: {laptop.Brand} | " +
        $"Model: {laptop.ModelName} | " +
        $"Office: {laptop.Office.OfficeName}"
    );
}


// SORT BY PURCHASE DATE
Console.WriteLine();
Console.WriteLine("SORTED BY PURCHASE DATE");
Console.WriteLine("-------------------------");

var sortedComputers = context.ComputerAssets
    .OrderBy(x => x.PurchaseDate)
    .ToList();

foreach (var computer in sortedComputers)
{
    Console.WriteLine(
        $"Brand: {computer.Brand} | " +
        $"Purchase Date: {computer.PurchaseDate.ToShortDateString()}"
    );
}

// MOBILE ASSETS
Console.WriteLine();
Console.WriteLine("MOBILE ASSETS");
Console.WriteLine("-------------------------");

var mobilesData = context.MobileAssets
    .Include(x => x.Office)
    .ToList();

foreach (var mobile in mobilesData)
{
    Console.WriteLine(
        $"Brand: {mobile.Brand} | " +
        $"Model: {mobile.ModelName} | " +
        $"Type: {mobile.MobileType} | " +
        $"Office: {mobile.Office.OfficeName} | " +
        $"User: {mobile.EmployeeUserName}"
    );
}

static string GetAssetStatus(DateTime warrantyExpirationDate)
{
    int remainingDays = (warrantyExpirationDate - DateTime.Now).Days;

    if (remainingDays < 90)
    {
        return "YELLOW";
    }
    else if (remainingDays < 180)
    {
        return "RED";
    }
    else
    {
        return "NORMAL";
    }
}
