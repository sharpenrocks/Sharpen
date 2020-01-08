using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen
{
    partial class AboutDialog
    {
        public class ConfigSection : ConfigurationSection
        {
            [ConfigurationProperty("gitHubAuthToken")]
            public string GitHubAuthToken => (string)this["gitHubAuthToken"];
            
            [ConfigurationProperty("gitHubLogin")]
            public string GitHubLogin => (string)this["gitHubLogin"];
            
            [ConfigurationProperty("gitHubRepository")]
            public string GitHubRepository => (string)this["gitHubRepository"];

            [ConfigurationProperty("vSMarketplaceID")]
            public string VSMarketplaceID => (string)this["vSMarketplaceID"];
        }
    }
}
