using System.Configuration;

namespace Sharpen
{
    internal class AboutDialogConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("gitHubAuthToken")]
        public string GitHubAuthToken => (string)this["gitHubAuthToken"];

        [ConfigurationProperty("gitHubLogin")]
        public string GitHubLogin => (string)this["gitHubLogin"];

        [ConfigurationProperty("gitHubRepository")]
        public string GitHubRepository => (string)this["gitHubRepository"];

        [ConfigurationProperty("vSMarketplaceId")]
        public string VSMarketplaceId => (string)this["vSMarketplaceId"];
    }
}
