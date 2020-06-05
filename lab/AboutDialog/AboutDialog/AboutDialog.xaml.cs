using System.Configuration;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace Sharpen
{
    public partial class AboutDialog : Window
    {
        private readonly AboutDialogData data = new AboutDialogData();

        public AboutDialog()
        {
            InitializeComponent();
            DataContext = data;
        }

        private void HyperlinkRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
        }

        private void BtnCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void WindowLoaded(object sender, RoutedEventArgs e)
        {            
            await data.LoadAsync();
        }
    }
}
