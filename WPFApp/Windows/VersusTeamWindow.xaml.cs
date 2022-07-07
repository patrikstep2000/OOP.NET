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
    public partial class VersusTeamWindow : Window
    {
        public Team VersusTeam { get; set; }
        public VersusTeamWindow(IList<Team> teams)
        {
            InitializeComponent();
            cbTeams.ItemsSource = teams;
            cbTeams.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            VersusTeam = (Team)cbTeams.SelectedItem;
            DialogResult = true;
            Close();
        }
    }
}
