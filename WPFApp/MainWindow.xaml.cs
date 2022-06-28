using DAL.Models;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPFApp.Windows;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRepo repo;
        private AppSettings settings;

        private InitialSettingsWindow settingsWindow = new InitialSettingsWindow();

        public MainWindow()
        {
            InitializeComponent();
            repo = RepoFactory.GetRepository();
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                settings = repo.GetSettings();
                if (settings.Resolution == Resolution.Undefined)
                {
                    if (settings.WorldCup == "men")
                    {
                        settingsWindow.btnMen.IsChecked = true;
                    }
                    else
                    {
                        settingsWindow.btnWomen.IsChecked = true;
                    }

                    if (settings.Language == "croatian")
                    {
                        settingsWindow.btnCroatian.IsChecked = true;
                    }
                    else
                    {
                        settingsWindow.btnEnglish.IsChecked = true;
                    }

                    if (settingsWindow.ShowDialog() != null)
                    {
                        settings.WorldCup = settingsWindow.WorldCup;
                        settings.Language = settingsWindow.Lang;
                        settings.Resolution = settingsWindow.Resolution;
                    }
                }
                ApplyResolution();
            }
            catch
            {
                settings = new AppSettings();
                if (settingsWindow.ShowDialog() != null)
                {
                    settings.WorldCup = settingsWindow.WorldCup;
                    settings.Language = settingsWindow.Lang;
                    settings.Resolution = settingsWindow.Resolution;
                    ApplyResolution();
                }
            }
        }

        private void ApplyResolution()
        {
            switch (settings.Resolution)
            {
                case Resolution.Fullscreen:
                    WindowState = WindowState.Maximized;
                    WindowStyle = WindowStyle.None;
                    break;
                case Resolution.Large:
                    WindowState = WindowState.Normal;
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    Width = 1200;
                    Height = 900;
                    break;
                case Resolution.Medium:
                    WindowState = WindowState.Normal;
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    Width = 1000;
                    Height = 750;
                    break;
                case Resolution.Small:
                    WindowState = WindowState.Normal;
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    Width = 800;
                    Height = 600;
                    break;
                default:
                    WindowState = WindowState.Maximized;
                    WindowStyle = WindowStyle.None;
                    break;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                repo.SaveSettings(settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            base.OnClosing(e);
        }
    }
}
