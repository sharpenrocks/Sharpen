using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace Sharpen
{
    public static class BitmapExtensions
    {
        // https://stackoverflow.com/questions/94456/load-a-wpf-bitmapimage-from-a-system-drawing-bitmap
        /// <summary>
        /// Converts Bitmap to BitmapImage.
        /// </summary>
        /// <param name="source">Bitmap to convert</param>
        /// <returns>System.Drawing.Bitmap</returns>
        public static  BitmapImage ConvertToBitmapImage(this Bitmap source)
        {
            using (var stream = new MemoryStream())
            {
                source.Save(stream, ImageFormat.Png);

                stream.Position = 0;
                var result = new BitmapImage();
                result.BeginInit();
                // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                // Force the bitmap to load right now so we can dispose the stream.
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();

                return result;
            }
        }
    }
}
