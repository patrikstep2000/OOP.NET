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
    public partial class SettingsWindow : Window
    {
        public string WorldCup { get; set; }
        public string Lang { get; set; }
        public Resolution Resolution { get; set; }

        public SettingsWindow(AppSettings settings)
        {
            InitializeComponent();
            if (settings != null)
            {
                SetSelectedWc(settings.WorldCup);
                SetSelectedLanguage(settings.Language);
                SetSelectedResolution(settings.Resolution);
            }
        }

        private void SetSelectedLanguage(string lang)
        {
            if (lang != null)
            {
                if (lang == "english")
                {
                    btnEnglish.IsChecked = true;
                }
                else
                {
                    btnCroatian.IsChecked = true;
                }
            }
        }

        private void SetSelectedWc(string wc)
        {
            if (wc != null)
            {
                if (wc == "men")
                {
                    btnMen.IsChecked = true;
                }
                else
                {
                    btnWomen.IsChecked = true;
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ConfirmDialog cd = new ConfirmDialog("Confirm settings");
            if (cd.ShowDialog() == true)
            {
                WorldCup = (bool)btnMen.IsChecked ? "men" : "women";
                Lang = (bool)btnCroatian.IsChecked ? "croatian" : "english";
                Resolution = GetResolution();
                DialogResult = true;
                Close(); 
            }
        }

        public void SetSelectedResolution(Resolution res)
        {
            switch (res)
            {
                case Resolution.Undefined:
                    cbResolution.SelectedIndex = 0;
                    break;
                case Resolution.Fullscreen:
                    cbResolution.SelectedIndex = 0;
                    break;
                case Resolution.Large:
                    cbResolution.SelectedIndex = 1;
                    break;
                case Resolution.Medium:
                    cbResolution.SelectedIndex = 2;
                    break;
                case Resolution.Small:
                    cbResolution.SelectedIndex = 3;
                    break;
            }
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
