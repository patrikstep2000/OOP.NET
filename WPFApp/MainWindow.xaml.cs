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
using WPFApp.Models;
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

        private Size miniPlayerSize = new Size(30, 30);
        private int miniPlayerMargin;

        private InitialSettingsWindow settingsWindow = new InitialSettingsWindow();
        private FavouriteTeamWindow favouriteTeamWindow;
        private VersusTeamWindow versusTeamWindow;

        private LoadingWindow loadingWindow;
        private TeamStatsWindow statsWindow;

        private IList<Team> _teams;
        private Team versusTeam;
        private Match match;

        public MainWindow()
        {
            InitializeComponent();
            repo = RepoFactory.GetRepository();
            LoadSettings();
            StartApp();
        }

        private async void StartApp()
        {
            try
            {
                ShowLoading();
                _teams = await Task.Run(LoadTeams);
                CloseLoading();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            if (settings.FavouriteTeam == null)
            {
                if (_teams != null)
                {
                    favouriteTeamWindow = new FavouriteTeamWindow(_teams);
                    if (favouriteTeamWindow.ShowDialog() != null)
                    {
                        settings.FavouriteTeam = favouriteTeamWindow.FavouriteTeam;
                        lbFavouriteTeam.Content = favouriteTeamWindow.FavouriteTeam;
                    }
                }
                else
                {
                    MessageBox.Show("Can't load teams.");
                    return;
                }
            }

            if (settings.FavouriteTeam == null)
            {
                MessageBox.Show("Favourite team is null.");
                return;
            }

            ISet<Match> matches = null;
            try
            {
                ShowLoading();
                matches = await Task.Run(LoadMatches);
                CloseLoading();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            IList<Team> versusTeams = new List<Team>();
            if (matches != null)
            {
                foreach (Match m in matches)
                {
                    if (m.HomeTeamCountry == settings.FavouriteTeam.Country)
                    {
                        versusTeams.Add(_teams.FirstOrDefault(t => t.Country == m.AwayTeamCountry));
                    }
                    else if (m.AwayTeamCountry == settings.FavouriteTeam.Country)
                    {
                        versusTeams.Add(_teams.FirstOrDefault(t => t.Country == m.HomeTeamCountry));
                    }
                } 
            }

            if (versusTeams != null)
            {
                versusTeamWindow = new VersusTeamWindow(versusTeams);
                if (versusTeamWindow.ShowDialog() != null)
                {
                    versusTeam = versusTeamWindow.VersusTeam;
                    lbVersusTeam.Content = versusTeam;
                }
            }
            
            try
            {
                ShowLoading();
                match = await Task.Run(LoadMatch);
                CloseLoading();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            if (match != null)
            {
                if (match.HomeTeamCountry == settings.FavouriteTeam.Country)
                {
                    lbScore.Content = $"{match.HomeTeam.Goals} : {match.AwayTeam.Goals}";
                }
                else
                {
                    lbScore.Content = $"{match.AwayTeam.Goals} : {match.HomeTeam.Goals}";
                }
                LoadPlayers();
            }
        }

        private void LoadPlayers()
        {
            Color homeColor = Color.FromRgb(146, 202, 244);
            Color awayColor = Color.FromRgb(237, 74, 84);
            if (match.HomeTeamCountry == settings.FavouriteTeam.Country)
            {
                foreach (Player player in match.HomeTeamStatistics.StartingEleven)
                {
                    AppendHomePlayer(player, homeColor);
                }
                foreach (Player player in match.AwayTeamStatistics.StartingEleven)
                {
                    AppendAwayPlayer(player, awayColor);
                }
            }
            else
            {
                foreach (Player player in match.AwayTeamStatistics.StartingEleven)
                {
                    AppendHomePlayer(player, homeColor);
                }
                foreach (Player player in match.HomeTeamStatistics.StartingEleven)
                {
                    AppendAwayPlayer(player, awayColor);
                }
            }
        }

        private void AppendAwayPlayer(Player player, Color color)
        {
            switch (player.Position)
            {
                case "Goalie":
                    wpAwayGoalie.Children.Add(new MiniPlayerControl(player, miniPlayerSize, miniPlayerMargin, color));
                    break;
                case "Defender":
                    wpAwayDefenders.Children.Add(new MiniPlayerControl(player, miniPlayerSize, miniPlayerMargin, color));
                    break;
                case "Midfield":
                    wpAwayMidfielders.Children.Add(new MiniPlayerControl(player, miniPlayerSize, miniPlayerMargin, color));
                    break;
                case "Forward":
                    wpAwayAttackers.Children.Add(new MiniPlayerControl(player, miniPlayerSize, miniPlayerMargin, color));
                    break;
            }
        }
        private void AppendHomePlayer(Player player, Color color)
        {
            switch (player.Position)
            {
                case "Goalie":
                    wpHomeGoalie.Children.Add(new MiniPlayerControl(player, miniPlayerSize, miniPlayerMargin, color));
                    break;
                case "Defender":
                    wpHomeDefenders.Children.Add(new MiniPlayerControl(player, miniPlayerSize, miniPlayerMargin, color));
                    break;
                case "Midfield":
                    wpHomeMidfielders.Children.Add(new MiniPlayerControl(player, miniPlayerSize, miniPlayerMargin, color));
                    break;
                case "Forward":
                    wpHomeAttackers.Children.Add(new MiniPlayerControl(player, miniPlayerSize, miniPlayerMargin, color));
                    break;
            }
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
                    FieldGrid.Width = 600;
                    FieldGrid.Height = 900;
                    miniPlayerSize = new Size(70, 70);
                    miniPlayerMargin = 30;
                    break;
                case Resolution.Large:
                    WindowState = WindowState.Normal;
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    Width = 1200;
                    Height = 900;
                    FieldGrid.Width = 400;
                    FieldGrid.Height = 600;
                    miniPlayerSize = new Size(45, 45);
                    miniPlayerMargin = 20;
                    break;
                case Resolution.Medium:
                    WindowState = WindowState.Normal;
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    Width = 1000;
                    Height = 750;
                    FieldGrid.Width = 300;
                    FieldGrid.Height = 450;
                    miniPlayerSize = new Size(40, 40);
                    miniPlayerMargin = 15;
                    break;
                case Resolution.Small:
                    WindowState = WindowState.Normal;
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    Width = 800;
                    Height = 600;
                    miniPlayerSize = new Size(25, 25);
                    miniPlayerMargin = 10;
                    break;
                default:
                    WindowState = WindowState.Maximized;
                    WindowStyle = WindowStyle.None;
                    break;
            }
        }


        //Loading functions
        private void ShowLoading()
        {
            loadingWindow = new LoadingWindow();
            loadingWindow.Show();
        }
        private void CloseLoading()
        {
            loadingWindow.Close();
        }


        //Get functions
        private Match LoadMatch()
        {
            return repo.GetMatchForCountry(settings.WorldCup, settings.FavouriteTeam.FifaCode).FirstOrDefault(m =>
            {
                if (m.HomeTeamCountry == settings.FavouriteTeam.Country)
                {
                    if (m.AwayTeamCountry == versusTeam.Country)
                    {
                        return true;
                    }
                }
                else if (m.AwayTeamCountry == settings.FavouriteTeam.Country)
                {
                    if (m.HomeTeamCountry == versusTeam.Country)
                    {
                        return true;
                    }
                }
                return false;
            });
        }
        private ISet<Match> LoadMatches()
        {
            return new HashSet<Match>(repo.GetMatchForCountry(settings.WorldCup, settings.FavouriteTeam.FifaCode));
        }
        private IList<Team> LoadTeams()
        {
            return repo.GetTeams(settings.WorldCup);
        }

        //stats
        private async void BtnFavouriteTeamStats_Click(object sender, RoutedEventArgs e)
        {
            if (settings.FavouriteTeam == null)
            {
                MessageBox.Show("Favourite team is null.");
                return;
            }
            ShowLoading();
            TeamResult result = await Task.Run(() => repo.GetTeamResults(settings.WorldCup).ToList().FirstOrDefault(r =>
            {
                if (r.Country == settings.FavouriteTeam.Country)
                {
                    return true;
                }
                return false;
            }));
            CloseLoading();
            statsWindow = new TeamStatsWindow(result);
            statsWindow.Show();
        }
        private async void BtnVersusTeamStats_Click(object sender, RoutedEventArgs e)
        {
            if (versusTeam == null)
            {
                MessageBox.Show("Versus team is null.");
                return;
            }

            ShowLoading();
            TeamResult result = await Task.Run(() => repo.GetTeamResults(settings.WorldCup).ToList().FirstOrDefault(r =>
            {
                if (r.Country == versusTeam.Country)
                {
                    return true;
                }
                return false;
            }));
            CloseLoading();
            statsWindow = new TeamStatsWindow(result);
            statsWindow.Show();
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                //repo.SaveSettings(settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            base.OnClosing(e);
        }
    }
}