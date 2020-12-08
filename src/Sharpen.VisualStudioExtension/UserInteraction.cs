using System.Windows;

namespace Sharpen.VisualStudioExtension
{
    internal static class UserInteraction
    {
        public static void ShowPlainMessage(string message, string caption = "Sharpen")
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.None);
        }

        public static void ShowInformation(string message, string caption = "Sharpen")
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void ShowError(string message, string caption = "Sharpen")
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
