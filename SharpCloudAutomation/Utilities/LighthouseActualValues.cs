//using LighthouseDotnet;
using lighthouse.net;

namespace SharpCloudAutomation.Utilities
{
    public class LighthouseActualValues : Base
    {
        public decimal Performance { get; set; }
        public decimal Accessibility { get; set; }
        public decimal Seo { get; set; }
        public LighthouseActualValues(string storyUrl)
        {
            var lh = new Lighthouse();
            var res = lh.Run(storyUrl).Result;
            Assert.IsNotNull(res);
            Performance = (decimal)(res.Performance != null ? res.Performance * 100 : 0);
            Accessibility = (decimal)(res.Accessibility != null ? res.Accessibility * 100 : 0);
            Seo = (decimal)(res.Seo != null ? res.Seo * 100 : 0);
        }
    }
}