using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.Utilities
{
    public class LightHouseBaseValue
    {
        public string Scenario { get; set; }

        public bool IsLogin { get; set; }

        public decimal Performance { get; set; }

        public decimal Accessibility { get; set; }

        public decimal Seo { get; set; }

        public string StoryUrl { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
