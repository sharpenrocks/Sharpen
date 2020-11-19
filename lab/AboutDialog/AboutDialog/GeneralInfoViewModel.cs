using System.Reflection;
using System.Threading.Tasks;

namespace Sharpen
{
    internal class GeneralInfoViewModel : BindableBase
    {
        private string? title;
        private string? description;
        private string? copyright;

        public string? Title { get => title; set => SetProperty(ref title, value); }
        public string? Description { get => description; set => SetProperty(ref description, value); }
        public string? Copyright { get => copyright; set => SetProperty(ref copyright, value); }

        internal Task SetGeneralInfoAsync()
        {
            var assembly = Assembly.GetEntryAssembly();

            // Set Title.
            var name = assembly.GetName();
            Title = $"{name.Name} v{name.Version}";

            // Set Description.
            var descriptionAttribute = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>();
            if (descriptionAttribute != null)
                Description = descriptionAttribute.Description;

            // Set Copyright.
            var copyrightAttribute = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>();
            if (copyrightAttribute != null)
                Copyright = copyrightAttribute.Copyright;

            return Task.CompletedTask;
        }
    }
}
