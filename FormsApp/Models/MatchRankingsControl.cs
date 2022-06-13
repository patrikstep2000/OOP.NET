using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp.Models
{
    public partial class MatchRankingsControl : UserControl
    {
        private Match _match;

        public MatchRankingsControl(Match match)
        {
            InitializeComponent();
            _match = match;
            InitLabels();
        }

        private void InitLabels()
        {
            lbLocation.Text = _match.Location;
            lbAttendance.Text = _match.Attendance.ToString();
            lbHomeTeam.Text = _match.HomeTeam.ToString();
            lbAwayTeam.Text = _match.AwayTeam.ToString();
        }
    }
}
