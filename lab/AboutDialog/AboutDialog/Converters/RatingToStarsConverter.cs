using System;
using System.Drawing;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Sharpen
{
    [ValueConversion(typeof(double), typeof(BitmapImage))]
    internal class RatingToStarsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is double))
                return null;

            double rating = (double)value;
            double roundedRating = Math.Round(rating * 2, MidpointRounding.AwayFromZero) / 2;

            var stars = new Bitmap(50, 10);

            using (var fullStar = new Bitmap("Resources/Rating.FullStar.png"))
            using (var halfStar = new Bitmap("Resources/Rating.HalfStar.png"))
            using (var noStar = new Bitmap("Resources/Rating.HalfStar.png"))
            using (var g = Graphics.FromImage(stars))
                for (int i = 1; i <= 5; i++)
                {
                    var x = (i - 1) * 10;

                    var img = noStar;
                    if ((int)roundedRating >= i)
                        img = fullStar;
                    else if ((int)roundedRating + 1 == i && (roundedRating % 1) == 0.5)
                        img = halfStar;

                    g.DrawImage(img, x, 0);
                }
            return stars.ConvertToBitmapImage();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
