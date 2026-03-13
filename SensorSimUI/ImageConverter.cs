using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using SensorSimModel.Interfaces;

namespace SensorSimUI;

public class ImageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        /*if (value is ISensorDisplayModel sensor && !string.IsNullOrEmpty(sensor.SensorImage.ImagePath))
        {
            var image = new BitmapImage(new Uri(sensor.SensorImage.ImagePath, UriKind.Relative));
            image.Freeze();
            return image;
        }
        return null;*/
        if (value is string path && !string.IsNullOrEmpty(path))
        {
            var image = new BitmapImage(new Uri(path, UriKind.Relative));
            image.Freeze();
            return image;
        }
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}