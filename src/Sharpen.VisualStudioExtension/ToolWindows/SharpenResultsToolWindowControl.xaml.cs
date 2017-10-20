using System.Windows;

namespace Sharpen.VisualStudioExtension.ToolWindows
{
    public partial class SharpenResultsToolWindowControl
    {
        public SharpenResultsToolWindowControl()
        {
            InitializeComponent();
        }

        private void OnClickMeClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanks for clicking me :-)", "Sharpen Results");
        }
    }
}