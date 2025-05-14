using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using Restaurant.ViewModels.ObjectViewModels;
using System.Windows.Controls.Primitives;

namespace Restaurant.Helpers;
public static class ImageHelper
{
    public static ImageSource CreateMenuImageCollage(IEnumerable<MenuItemViewModel> menuItems, IEnumerable<ProductViewModel> products)
    {
        var grid = new UniformGrid
        {
            Rows = 2,
            Columns = 2,
            Width = 100,
            Height = 100
        };

        foreach (var item in menuItems.Take(4))
        {
            var product = products.FirstOrDefault(p => p.Id == item.ProductId);
            if (product != null && !string.IsNullOrEmpty(product.ImagePath))
            {
                var image = new Image
                {
                    Source = new BitmapImage(new Uri(product.ImagePath, UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.UniformToFill
                };
                grid.Children.Add(image);
            }
        }

        grid.Measure(new Size(100, 100));
        grid.Arrange(new Rect(0, 0, 100, 100));

        var renderBitmap = new RenderTargetBitmap(100, 100, 96, 96, PixelFormats.Pbgra32);
        renderBitmap.Render(grid);

        return renderBitmap;
    }
}