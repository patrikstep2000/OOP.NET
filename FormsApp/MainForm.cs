using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Repo;
using DAL.Models;
using RestSharp;
using FormsApp.Forms;
using System.IO;
using FormsApp.Models;
using System.Threading;
using System.Globalization;

namespace FormsApp
{
    public partial class MainForm : Form
    {
        public readonly IRepo _repo;

        private bool _disposed = false;
        public AppSettings _settings;

        private FavouriteTeamForm favTeamForm;
        private ExitForm exitForm;
        private LoadingForm loadingForm;
        private bool isLoading;

        private IList<Team> _teams;
        public IList<Player> _players;
        private IList<Match> _matches;

        private List<Player> _goalSortedPlayers;
        private List<Player> _yellowCardSortedPlayers;
        private List<Match> _visitorSortedMatches;

        private Color selectedColor = Color.LightGray;
        private Color unselectedColor = Color.White;
        private List<PlayerControl> _selectedPlayers = new List<PlayerControl>();
        private List<PlayerControl> _selectedFavPlayers = new List<PlayerControl>();
        private FlowLayoutPanel panelStartedDnD;

        private const string HR = "hr";
        private const string EN = "en";

        public MainForm()
        {
            InitializeComponent();
            //init repo
            _repo = RepoFactory.GetRepository();
                    
            //init settings
            if (!InitSettings())
            {
                _disposed = true;
                return;
            }

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                //init favourite team and players in the background
                if (_settings.FavouriteTeam == null)
                {
                    favouriteTeamWorker.RunWorkerAsync();
                }
                else
                {
                    favouritePlayersWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Loading functions
        private void ShowLoading()
        {
            MethodInvoker methodInvokerDelegate = delegate ()
            {
                loadingForm = new LoadingForm();
                loadingForm.Show();
                isLoading = true;
            };
            this.Invoke(methodInvokerDelegate);
        }
        private void CloseLoading()
        {
            MethodInvoker methodInvokerDelegate = delegate ()
            {
                loadingForm.Close();
                isLoading = false;
            };
            this.Invoke(methodInvokerDelegate);
        }


        //Settings
        private bool InitSettings()
        {
            try
            {
                _settings = _repo.GetSettings();
                SetCulture(_settings.Language == "croatian" ? HR : EN);
                return true;
            }
            catch (Exception)
            {
                SettingsForm settingsForm = new SettingsForm(true);
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    _settings = new AppSettings
                    {
                        WorldCup = settingsForm.WorldCup,
                        Language = settingsForm.Language
                    };
                    SetCulture(_settings.Language == "croatian" ? HR : EN);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private void SetSettings()
        {
            SettingsForm settingsForm = new SettingsForm(false);
            if (_settings.WorldCup == "men")
            {
                settingsForm.rbtnMen.Select();
            }
            else
            {
                settingsForm.rbtnWomen.Select();
            }
            if (_settings.Language == "croatian")
            {
                settingsForm.rbtnCroatian.Select();
            }
            else
            {
                settingsForm.rbtnEnglish.Select();
            }


            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                if (_settings.WorldCup != settingsForm.WorldCup)
                {
                    ChangeLanguage(settingsForm.Language);
                    _settings.WorldCup = settingsForm.WorldCup;
                    _settings.FavouritePlayers.Clear();
                    try
                    {
                        favouriteTeamWorker.RunWorkerAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if(settingsForm.Language != _settings.Language)
                {
                    ChangeLanguage(settingsForm.Language);
                    LoadData();
                }
            }
            else
            {
                return;
            }
        }

        private void ChangeLanguage(string language)
        {
            if (language == _settings.Language)
            {
                return;
            }
            else
            {
                _settings.Language = language;
                if (language == "croatian")
                {
                    SetCulture(HR);
                }
                else
                {
                    SetCulture(EN);
                }
            }
        }
        private void SetCulture(string lang)
        {
            CultureInfo culture = new CultureInfo(lang);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            this.Controls.Clear();
            InitializeComponent();
        }


        //Background workers
        private void FavouriteTeamWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ShowLoading();
                _teams = _repo.GetTeams(_settings.WorldCup);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FavouriteTeamWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                CloseLoading();
                if (_teams != null)
                {
                    favTeamForm = new FavouriteTeamForm(_teams, _settings.FavouriteTeam);
                    if (favTeamForm.ShowDialog() == DialogResult.OK)
                    {
                        if (_settings.FavouriteTeam != null && _settings.FavouriteTeam.ToString() == favTeamForm.SelectedTeam.ToString())
                        {
                            return;
                        }
                        else
                        {
                            _settings.FavouriteTeam = favTeamForm.SelectedTeam;
                            favouritePlayersWorker.RunWorkerAsync();
                        }
                    }
                }
                else
                {
                    throw new Exception("Can't fetch teams data.");
                }           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FavouritePlayersWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ShowLoading();
                _matches = _repo.GetMatchForCountry(_settings.WorldCup, _settings.FavouriteTeam.FifaCode);
                Match match = _matches.First();
                _players = match.HomeTeamCountry == _settings.FavouriteTeam.Country ? match.HomeTeamStatistics.StartingEleven.Union(match.HomeTeamStatistics.Substitutes).ToList() : match.AwayTeamStatistics.StartingEleven.Union(match.AwayTeamStatistics.Substitutes).ToList();

                FillPlayerStats();

                if (_settings.FavouritePlayers == null)
                {
                    _settings.FavouritePlayers = new List<Player>();
                }
                if (_settings.FavouritePlayers.Count > 0)
                {
                    foreach (Player player in _settings.FavouritePlayers)
                    {
                        _players.Remove(player);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FavouritePlayersWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                CloseLoading();
                this.Invoke(new MethodInvoker(() =>
                {
                    flowPanelFavPlayers.Controls.Clear();
                    flowPanelAllPlayers.Controls.Clear();
                    if (_settings.FavouritePlayers.Count > 0)
                    {
                        foreach (Player player in _settings.FavouritePlayers)
                        {
                            PlayerControl pc = new PlayerControl(player, _repo);
                            pc.playerPanel.MouseDown += PlayerControl_MouseDown;
                            pc.playerPanel.DoubleClick += PlayerControl_DoubleClick;
                            flowPanelFavPlayers.Controls.Add(pc);
                        }
                    }
                    foreach (Player player in _players)
                    {
                        PlayerControl pc = new PlayerControl(player, _repo);
                        pc.playerPanel.MouseDown += PlayerControl_MouseDown;
                        pc.playerPanel.DoubleClick += PlayerControl_DoubleClick;
                        flowPanelAllPlayers.Controls.Add(pc);
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillPlayerStats()
        {

            foreach (Player p in _players)
            {
                int goalCount = 0;
                int yellowCardCount = 0;

                foreach (Match match in _matches)
                {
                    if (match.AwayTeamCountry == _settings.FavouriteTeam.Country)
                    {
                        foreach (TeamEvent te in match.AwayTeamEvents)
                        {
                            if (te.Player.ToLower() == p.Name.ToLower())
                            {
                                if (te.TypeOfEvent == "goal")
                                {
                                    goalCount++;
                                }
                                if (te.TypeOfEvent == "yellow-card")
                                {
                                    yellowCardCount++;
                                }
                            }
                        }
                    }
                    if (match.HomeTeamCountry == _settings.FavouriteTeam.Country)
                    {
                        foreach (TeamEvent te in match.HomeTeamEvents)
                        {
                            if (te.Player == p.Name)
                            {
                                if (te.TypeOfEvent == "goal")
                                {
                                    goalCount++;
                                }
                                if (te.TypeOfEvent == "yellow-card")
                                {
                                    yellowCardCount++;
                                }
                            }
                        }
                    }
                }

                p.NumberOfGoals = goalCount;
                p.NumberOfYellowCards = yellowCardCount;
            }
        }


        //Changing settings
        private void ChangeWorldCupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLoading)
            {
                return;
            }
            Tabs.SelectedTab = tabPagePlayers;
            ClearSelectedPlayers();
            SetSettings();       
        }
        private void ChangeFavouriteTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLoading)
            {
                return;
            }
            _settings.FavouritePlayers = null;
            Tabs.SelectedTab = tabPagePlayers;
            ClearSelectedPlayers();
            try
            {
                favouriteTeamWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        
        //Rankings solution
        private void FillRankings()
        {
            _visitorSortedMatches.ForEach(m => flowPanelVisitors.Controls.Add(new MatchRankingsControl(m)));
            _goalSortedPlayers.ForEach(p => flowPanelGoals.Controls.Add(new PlayerGoalRankingsControl(p, _repo)));
            _yellowCardSortedPlayers.ForEach(p => flowPanelYellowCards.Controls.Add(new PlayerYellowCardRankingsControl(p, _repo)));
        }
        private void SortRankings()
        {

            _visitorSortedMatches = new List<Match>(_matches);
            _visitorSortedMatches.Sort((a, b) => -a.Attendance.CompareTo(b.Attendance));

            _goalSortedPlayers = new List<Player>(_players.Union(_settings.FavouritePlayers));
            _goalSortedPlayers.Sort((a, b) => -a.NumberOfGoals.CompareTo(b.NumberOfGoals));

            _yellowCardSortedPlayers = new List<Player>(_players.Union(_settings.FavouritePlayers));
            _yellowCardSortedPlayers.Sort((a, b) => -a.NumberOfYellowCards.CompareTo(b.NumberOfYellowCards));
        }
        private void RankingsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowLoading();
            SortRankings();
        }
        private void RankingsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CloseLoading();
            this.Invoke(new MethodInvoker(() =>
            {
                FillRankings();
            }));
        }
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tabs.SelectedTab == tabPageRankings)
            {
                foreach (Control c in tabPageRankings.Controls)
                {
                    if (c is FlowLayoutPanel fp)
                    {
                        fp.Controls.Clear();
                    }
                }
                rankingsWorker.RunWorkerAsync();
            }
        }



        //DnD solution
        private void FlowPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (isLoading)
            {
                return;
            }
            e.Effect = DragDropEffects.Move;
            List<PlayerControl> pcs = (List<PlayerControl>)e.Data.GetData(typeof(List<PlayerControl>));
            if (panelStartedDnD == flowPanelAllPlayers)
            {
                MoveToFavourites(pcs);
            }
            if (panelStartedDnD == flowPanelFavPlayers)
            {
                RemoveFromFavourites(pcs);
            }
            ClearSelectedPlayers();
        }
        private void FlowPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (isLoading)
            {
                return;
            }
            FlowLayoutPanel panel = sender as FlowLayoutPanel;
            if (panel == panelStartedDnD)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void PlayerControl_MouseDown(object sender, MouseEventArgs e)
        {
            PlayerControl player = ((Panel)sender).Parent as PlayerControl;
            FlowLayoutPanel flp = player.Parent as FlowLayoutPanel;
            panelStartedDnD = flp;

            bool isSelected = (bool)player.Tag;

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (isSelected)
                {
                    if (flp == flowPanelAllPlayers)
                    {
                        player.DoDragDrop(_selectedPlayers, DragDropEffects.Copy);
                    }
                    else if (flp == flowPanelFavPlayers)
                    {
                        player.DoDragDrop(_selectedFavPlayers, DragDropEffects.Copy);
                    } 
                }
            }
        }
        private void PlayerControl_DoubleClick(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            PlayerControl selectedPlayer = (PlayerControl)panel.Parent;
            if (selectedPlayer.Parent == flowPanelAllPlayers)
            {
                _selectedFavPlayers.Clear();
                foreach (Control control in flowPanelFavPlayers.Controls)
                {
                    if (control is PlayerControl p)
                    {
                        UnselectPlayer(p);
                    }
                }
                if ((bool)selectedPlayer.Tag == false)
                {
                    SelectPlayer(selectedPlayer);
                    _selectedPlayers.Add(selectedPlayer);
                }
                else
                {
                    UnselectPlayer(selectedPlayer);
                    _selectedPlayers.Remove(selectedPlayer);
                }
            }
            else
            {
                _selectedPlayers.Clear();
                foreach (Control control in flowPanelAllPlayers.Controls)
                {
                    if (control is PlayerControl p)
                    {
                        UnselectPlayer(p);
                    }
                }
                if ((bool)selectedPlayer.Tag == false)
                {
                    SelectPlayer(selectedPlayer);
                    _selectedFavPlayers.Add(selectedPlayer);
                }
                else
                {
                    UnselectPlayer(selectedPlayer);
                    _selectedFavPlayers.Remove(selectedPlayer);
                }
            }
        }

        private void SelectPlayer(PlayerControl p)
        {
            if ((bool)p.Tag == false)
            {
                p.Tag = true;
                p.BackColor = selectedColor;
            }
        }
        private void UnselectPlayer(PlayerControl p)
        {
            if ((bool)p.Tag == true)
            {
                p.Tag = false;
                p.BackColor = unselectedColor; 
            }
        }
        private void ClearSelectedPlayers()
        {
            _selectedFavPlayers.Clear();
            _selectedPlayers.Clear();
        }


        //Moving players
        public void MoveToFavourites(PlayerControl pc)
        {
            if (flowPanelFavPlayers.Controls.Count + 1 > 3)
            {
                MessageBox.Show("Can't have more than 3 favourite players.");
                return;
            }
            pc.player.IsFavourite = true;
            UnselectPlayer(pc);

            _settings.FavouritePlayers.Add(pc.player);
            flowPanelFavPlayers.Controls.Add(pc);
            pc.InitLabels();

            flowPanelAllPlayers.Controls.Remove(pc);
            _players.Remove(pc.player);
        }
        public void MoveToFavourites(List<PlayerControl> pcs)
        {
            if (flowPanelFavPlayers.Controls.Count + pcs.Count > 3)
            {
                MessageBox.Show("Can't have more than 3 favourite players.");
                pcs.ToList().ForEach(p => UnselectPlayer(p));
                ClearSelectedPlayers();
                return;
            }
            foreach (PlayerControl pc in pcs)
            {
                MoveToFavourites(pc);
            }
        }

        public void RemoveFromFavourites(PlayerControl pc)
        {
            pc.player.IsFavourite = false;
            UnselectPlayer(pc);

            _players.Add(pc.player);
            flowPanelAllPlayers.Controls.Add(pc);
            pc.InitLabels();

            flowPanelFavPlayers.Controls.Remove(pc);
            _settings.FavouritePlayers.Remove(pc.player);
        }
        public void RemoveFromFavourites(List<PlayerControl> pcs)
        {
            foreach (PlayerControl pc in pcs)
            {
                RemoveFromFavourites(pc);
            }
        }


        //Printing
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (isLoading)
            {
                return;
            }
            try
            {
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float y = e.MarginBounds.Y - 20;
            float x = e.MarginBounds.X;
            int count = 0;

            Font headingFont = new Font("Arial", 12);
            Font txtFont = new Font("Arial", 10);

            e.Graphics.DrawString("Player rankings by scored goals:", headingFont, Brushes.Black, x, y);
            foreach (Player player in _goalSortedPlayers)
            {
                if (player == _goalSortedPlayers[0])
                {
                    e.Graphics.DrawString($"{count++}.\t" + player.ToPrintStringGoals(), txtFont, Brushes.Black, x, y += 25);
                }
                else
                {
                    e.Graphics.DrawString($"{count++}.\t" + player.ToPrintStringGoals(), txtFont, Brushes.Black, x, y += 13); 
                }
            }

            count = 0;
            e.Graphics.DrawString("Player rankings by yellow cards:", headingFont, Brushes.Black, x, y += 30);
            foreach (Player player in _yellowCardSortedPlayers)
            {
                if (player == _yellowCardSortedPlayers[0])
                {
                    e.Graphics.DrawString($"{count++}.\t" + player.ToPrintStringYellowCards(), txtFont, Brushes.Black, x, y += 20);
                }
                else
                {
                    e.Graphics.DrawString($"{count++}.\t" + player.ToPrintStringYellowCards(), txtFont, Brushes.Black, x, y += 13); 
                }
            }

            count = 0;
            e.Graphics.DrawString("Match rankings by attendance:", headingFont, Brushes.Black, x, y += 30);
            foreach (Match match in _visitorSortedMatches)
            {
                if (match == _visitorSortedMatches[0])
                {
                    e.Graphics.DrawString($"{count++}.\t" + match.ToPrintString(), txtFont, Brushes.Black, x, y += 20);
                }
                else
                {
                    e.Graphics.DrawString($"{count++}.\t" + match.ToPrintString(), txtFont, Brushes.Black, x, y += 35); 
                }
            }
        }
        private void BtnPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }


        //OnClose
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!_disposed)
            {
                try
                {
                    _repo.SaveSettings(_settings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }          
            }
            exitForm = new ExitForm();
            if (exitForm.ShowDialog() == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}