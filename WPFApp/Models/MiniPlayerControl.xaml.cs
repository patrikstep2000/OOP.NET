using DAL.Models;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;

namespace WPFApp.Models
{
    /// <summary>
    /// Interaction logic for MiniPlayerControl.xaml
    /// </summary>
    public partial class MiniPlayerControl : UserControl
    {
        public MiniPlayerControl(Player player, Size size, int margin, Color color)
        {
            InitializeComponent();
            Width = size.Width;
            Height = size.Height;
            Margin = new Thickness(margin, 0, margin, 0);
            border.Background = new SolidColorBrush(color);
            lbNumber.Content = player.ShirtNumber.ToString();
        }

        public System.Windows.Media.Brush CreateBrushFromBitmap(System.Drawing.Bitmap bitmap)
        {
            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                bitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return new ImageBrush(bitmapSource);
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
