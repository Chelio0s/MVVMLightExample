using System.Windows;
using System.Windows.Media;

namespace MVVMLigtAdvanced
{
    public static class AttachedProperty
    {

        public static void SetImageDataSource(DependencyObject element, ImageSource value)
        {
           element.SetValue(ImageDataSourceProperty, value);
        }

        public static ImageSource GetImageDataSource(DependencyObject element)
        {
            return (ImageSource)element.GetValue(ImageDataSourceProperty);
        }

        // Using a DependencyProperty as the backing store for ImageDataSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageDataSourceProperty =
            DependencyProperty.RegisterAttached("ImageDataSource", typeof(ImageSource), typeof(AttachedProperty), new PropertyMetadata(null));


    }
}
