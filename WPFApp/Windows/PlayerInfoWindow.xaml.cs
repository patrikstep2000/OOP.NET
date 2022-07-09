using DAL.Models;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApp.Windows
{
    /// <summary>
    /// Interaction logic for PlayerInfoWindow.xaml
    /// </summary>
    public partial class PlayerInfoWindow : Window
    {
        private IRepo repo;
        private Player player;
        private Match match;
        public PlayerInfoWindow(Player p, Match m)
        {
            InitializeComponent();
            player = p;
            match = m;
            repo = RepoFactory.GetRepository();
            SetImage();
            lbPlayerName.Content = player.Name;
            lbShirtNumber.Content = player.ShirtNumber;
            lbPosition.Content = player.Position;
            lbCaptain.Content = player.Captain;
            SetGoalsAndYellowCards();
        }

        private void SetGoalsAndYellowCards()
        {
            int goals = 0;
            int yellowCards = 0;
            foreach (TeamEvent e in match.HomeTeamEvents)
            {
                if (e.Player == player.Name)
                {
                    if (e.TypeOfEvent == "goal" || e.TypeOfEvent == "goal-penalty")
                    {
                        goals++;
                    }
                    if (e.TypeOfEvent == "yellow-card")
                    {
                        yellowCards++;
                    }
                }
            }
            foreach (TeamEvent e in match.AwayTeamEvents)
            {
                if (e.Player == player.Name)
                {
                    if (e.TypeOfEvent == "goal" || e.TypeOfEvent == "goal-penalty")
                    {
                        goals++;
                    }
                    if (e.TypeOfEvent == "yellow-card")
                    {
                        yellowCards++;
                    }
                }
            }

            lbGoalsScored.Content = goals;
            lbYellowCards.Content = yellowCards;
        }

        private void SetImage()
        {
            System.Drawing.Image img = repo.GetPlayerPicture(player);
            if (img != null)
            {
                Bitmap bitmap = new Bitmap(img);
                PlayerImg.Background = CreateBrushFromBitmap(bitmap); 
            }
        }

        public System.Windows.Media.Brush CreateBrushFromBitmap(System.Drawing.Bitmap bitmap)
        {
            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                bitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return new ImageBrush(bitmapSource);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
