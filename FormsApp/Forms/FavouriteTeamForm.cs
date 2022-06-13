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

namespace FormsApp.Forms
{
    public partial class FavouriteTeamForm : Form
    {
        public Team SelectedTeam { get; set; }

        public FavouriteTeamForm(IList<Team> teams, Team favTeam)
        {
            InitializeComponent();
            SetTeams(teams, favTeam);
        }

        private void cboxFavTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTeam = (Team)cboxFavTeam.SelectedItem;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboxFavTeam.SelectedItem != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            return;
        }

        private void cboxFavTeam_TextUpdate(object sender, EventArgs e)
        {
            cboxFavTeam.Text = "";
        }

        private void SetTeams(IList<Team> teams, Team favTeam)
        {
            foreach (Team team in teams)
            {
                cboxFavTeam.Items.Add(team);
            }
            int index = cboxFavTeam.FindStringExact(favTeam?.ToString());
            if (favTeam == null || index == -1)
            {
                cboxFavTeam.SelectedItem = teams[0];
            }
            else
            {
                cboxFavTeam.SelectedIndex = index;
            }
        }

        
    }
}
