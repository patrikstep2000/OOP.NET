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
    /// Interaction logic for TeamStatsWindow.xaml
    /// </summary>
    public partial class TeamStatsWindow : Window
    {
        public TeamStatsWindow(TeamResult result)
        {
            InitializeComponent();
            AppendData(result);
        }

        private void AppendData(TeamResult result)
        {
            lbTeamName.Content = result.ToString();
            lbPlayed.Content += $"\t\t{result.GamesPlayed}";
            lbWins.Content += $"\t\t{result.Wins}";
            lbLost.Content += $"\t\t{result.Losses}";
            lbDraws.Content += $"\t\t{result.Draws}";
            lbDifferential.Content += $"\t{result.GoalDifferential}";
            lbScored.Content += $"\t\t{result.GoalsFor}";
            lbReceived.Content += $"\t{result.GoalsAgainst}";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
