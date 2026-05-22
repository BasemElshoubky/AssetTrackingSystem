namespace AssetTrackingSystem.Models
{
    internal class Office
    {
        public int Id { get; set; }

        public string OfficeName { get; set; }

        public string Country { get; set; }

        public string Currency { get; set; }

        public List<ComputerAsset> ComputerAssets { get; set; }

        public List<MobileAsset> MobileAssets { get; set; }
    }
}