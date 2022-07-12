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
using WPFApp.Windows;

namespace WPFApp.Models
{
    /// <summary>
    /// Interaction logic for MiniPlayerControl.xaml
    /// </summary>
    public partial class MiniPlayerControl : UserControl
    {
        public Player player;
        private Color color;
        private Color selectedColor = Color.FromRgb(100, 100, 100);
        public MiniPlayerControl(Player player, Size size, int margin, Color c)
        {
            InitializeComponent();
            this.player = player;
            color = c;
            Width = size.Width;
            Height = size.Height;
            Margin = new Thickness(margin, 0, margin, 0);
            border.Background = new SolidColorBrush(color);
            lbNumber.Content = player.ShirtNumber.ToString();
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            border.Background = new SolidColorBrush(selectedColor);
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            border.Background = new SolidColorBrush(color);
        }
    }
}
