namespace SharpCloudAutomation.Utilities
{
    public class LightHouseBaseValue
    {
        public string? Scenario { get; set; }
        public bool IsLogin { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public decimal Performance { get; set; }
        public decimal Accessibility { get; set; }
        public decimal Seo { get; set; }
        public string? StoryUrl { get; set; }
    }
}