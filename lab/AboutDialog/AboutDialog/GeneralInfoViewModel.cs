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
            var assemblyName = assembly.GetName();
            Title = $"{assemblyName.Name} v{assemblyName.Version}";

            // Set Description.
            Description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;

            // Set Copyright.
            Copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;

            return Task.CompletedTask;
        }
    }
}
