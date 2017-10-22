using System.Windows;

namespace Sharpen.VisualStudioExtension
{
    internal static class UserInteraction
    {
        public static void ShowInformation(string message)
        {
            MessageBox.Show(message, "Sharpen", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Sharpen", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
