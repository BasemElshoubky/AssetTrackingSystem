namespace AssetTrackingSystem.Models
{
    internal class ComputerAsset : Asset
    {
        public string ComputerType { get; set; }

        public decimal LocalPrice { get; set; }

        public int OfficeId { get; set; }

        public Office Office { get; set; }
    }
}