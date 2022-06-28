using DAL.Models;
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
using System.Windows.Shapes;

namespace WPFApp.Windows
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class InitialSettingsWindow : Window
    {
        public string WorldCup { get; set; }
        public string Lang { get; set; }
        public Resolution Resolution { get; set; }

        public InitialSettingsWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            WorldCup = (bool)btnMen.IsChecked ? "men" : "women";
            Lang = (bool)btnCroatian.IsChecked ? "croatian" : "english";
            Resolution = GetResolution();
            DialogResult = true;
            Close();
        }

        private Resolution GetResolution()
        {
            ComboBoxItem cbi = (ComboBoxItem)cbResolution.SelectedItem;
            switch (cbi.Tag.ToString())
            {
                case "F":
                    return Resolution.Fullscreen;
                case "L":
                    return Resolution.Large;
                case "M":
                    return Resolution.Medium;
                case "S":
                    return Resolution.Small;
                default:
                    return Resolution.Fullscreen;
            }
        }
    }
}
