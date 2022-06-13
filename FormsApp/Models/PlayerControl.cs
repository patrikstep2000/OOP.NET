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
    public partial class PlayerControl : UserControl
    {
        public Player player;
        private IRepo _repo;
        

        public PlayerControl(Player p, IRepo repo)
        {
            InitializeComponent();
            _repo = repo;
            player = p;
            InitContextMenu();
            InitLabels();
            InitImage();
            InitFileDialog();
            Tag = false;
        }

        private void InitFileDialog()
        {
            fileDialog.Filter = "Pictures|*.jpeg;*.jpg;*.png;";
            fileDialog.FileName = "";
            fileDialog.Multiselect = false;
            fileDialog.Title = "Load picture...";
            fileDialog.InitialDirectory = Application.StartupPath;
        }

        private void InitContextMenu()
        {            
            ContextMenu = new ContextMenu(new MenuItem[] {new MenuItem("Change image", ContextMenuChangeImage_Click), new MenuItem("", ContextMenuMove_Click)});
        }

        private void ContextMenuMove_Click(object sender, EventArgs e)
        {
            var parent = Parent.Parent.Parent.Parent as MainForm;
            if (player.IsFavourite)
            {
                parent.RemoveFromFavourites(this);
            }
            else
            {
                parent.MoveToFavourites(this);
            }
            InitLabels();
        }

        private void ContextMenuChangeImage_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = _repo.GetImage(fileDialog.FileName);
                    pbPlayer.Image = img;
                    _repo.SavePlayerPicture(img, player);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void InitLabels()
        {
            lbPlayerName.Text = player.Name;
            lbNumber.Text = player.ShirtNumber.ToString();
            lbPosition.Text = player.Position;
            lbCaptain.Text = player.Captain ? "Yes" : "No";
            pbFavourite.Visible = player.IsFavourite ? true : false;
            ContextMenu.MenuItems[1].Text = player.IsFavourite ? "Remove from favorites" : "Move to favorites";        }

        private void InitImage()
        {
            try
            {
                Image img = _repo.GetPlayerPicture(player);
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
