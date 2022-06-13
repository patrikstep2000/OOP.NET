using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DAL.Repo
{
    public interface IRepo
    {
        IList<Match> GetMatchForCountry(string worldCup, string code);
        IList<Team> GetTeams(string worldCup);
        IList<TeamResult> GetTeamResults(string worldCup);
        IList<GroupResult> GetGroupResults(string worldCup);

        AppSettings GetSettings();
        void SaveSettings(AppSettings settings);

        void SavePlayerPicture(Image image, Player player);
        Image GetPlayerPicture(Player player);
        Image GetImage(string imgPath);
    }
}
