namespace AssetTrackingSystem.Models
{
    internal class MobileAsset : Asset
    {
        public string MobileType { get; set; }

        public decimal LocalPrice { get; set; }

        public int OfficeId { get; set; }

        public Office Office { get; set; }
    }
}