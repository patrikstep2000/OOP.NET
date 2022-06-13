using DAL.Models;
using DAL.Repo;
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
    public partial class PlayerYellowCardRankingsControl : UserControl
    {
        private Player _player;
        private IRepo _repo;

        public PlayerYellowCardRankingsControl(Player player, IRepo repo)
        {
            InitializeComponent();
            _repo = repo;
            _player = player;
            InitLabels();
        }

        private void InitLabels()
        {
            lbPlayerName.Text = _player.Name;
            lbNoOfYellowCards.Text = _player.NumberOfYellowCards.ToString();
            pbFavourite.Visible = _player.IsFavourite ? true : false;
            InitImage();
        }

        private void InitImage()
        {
            try
            {
                Image img = _repo.GetPlayerPicture(_player);
                if (img != null)
                {
                    pbPlayer.Image = img;
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
