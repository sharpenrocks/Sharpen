using System.Configuration;

namespace Sharpen
{
    /// <summary>
    /// Base class for view models that need access to AboutDialogConfigurationSection.
    /// </summary>
    internal class ConfigurationBaseViewModel : BindableBase
    {
        protected AboutDialogConfigurationSection configuration = (AboutDialogConfigurationSection)ConfigurationManager.GetSection("aboutDialogConfigurationSection");
    }
}
