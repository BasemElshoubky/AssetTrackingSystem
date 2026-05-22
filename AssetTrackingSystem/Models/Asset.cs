namespace AssetTrackingSystem.Models
{
    internal abstract class Asset
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string ModelName { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal PurchasePriceUsd { get; set; }

        public string SerialNumber { get; set; }

        public string EmployeeUserName { get; set; }

        public DateTime WarrantyExpirationDate { get; set; }
    }
}