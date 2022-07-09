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
    /// Interaction logic for FavouriteTeamWindow.xaml
    /// </summary>
    public partial class FavouriteTeamWindow : Window
    {
        public Team FavouriteTeam { get; set; }

        public FavouriteTeamWindow(IList<Team> teams)
        {
            InitializeComponent();
            cbTeams.ItemsSource = teams;
            SetFavouriteTeam();
        }

        public void SetFavouriteTeam()
        {
            if (FavouriteTeam != null)
            {
                cbTeams.SelectedIndex = cbTeams.Items.IndexOf(FavouriteTeam);
            }
            else
            {
                cbTeams.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            FavouriteTeam = (Team)cbTeams.SelectedItem;
            DialogResult = true;
            Close();
        }
    }
}
