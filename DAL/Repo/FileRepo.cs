using DAL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public partial class FileRepo : IRepo
    {
        private const string MEN_DIR = @"..\..\..\DAL\JSONData\men\";
        private const string WOMEN_DIR = @"..\..\..\DAL\JSONData\women\";

        private static string PLAYER_IMAGE_BASE_DIR = RepoFactory.SETTINGS_DIR + @"\PlayerImages\";
    }

    public partial class FileRepo : IRepo
    {   
        public void SaveSettings(AppSettings settings)
        {
            try
            {
                if (!Directory.Exists(RepoFactory.SETTINGS_DIR))
                {
                    Directory.CreateDirectory(RepoFactory.SETTINGS_DIR);
                }
                File.WriteAllText(RepoFactory.SETTINGS_FILE, settings.Serialize());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public AppSettings GetSettings()
        {
            try
            {
                return AppSettings.FromJson(File.ReadAllText(RepoFactory.SETTINGS_FILE));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Match> GetMatchForCountry(string worldCup, string code)
        {
            return worldCup == "men" ? GetMenMatchForCountry(code) : GetWomenMatchForCountry(code);
        }
        public IList<Team> GetTeams(string worldCup)
        {
            return worldCup == "men" ? GetMenTeams() : GetWomenTeams();
        }
        public IList<TeamResult> GetTeamResults(string worldCup)
        {
            return worldCup == "men" ? GetMenTeamResults() : GetWomenTeamResults();
        }
        public IList<GroupResult> GetGroupResults(string worldCup)
        {
            return worldCup == "men" ? GetMenGroupResults() : GetWomenGroupResults();
        }


        public Image GetPlayerPicture(Player player)
        {
            try
            {
                return Image.FromFile(PLAYER_IMAGE_BASE_DIR + player.Name + ".png");
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void SavePlayerPicture(Image image, Player player)
        {
            try
            {
                if (!Directory.Exists(PLAYER_IMAGE_BASE_DIR))
                {
                    Directory.CreateDirectory(PLAYER_IMAGE_BASE_DIR);
                }
                image.Save(PLAYER_IMAGE_BASE_DIR + player.Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Image GetImage(string imgPath)
        {
            try
            {
                return Image.FromFile(imgPath);
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        private IList<GroupResult> GetMenGroupResults()
        {
            try
            {
                return  GroupResult.FromJson(File.ReadAllText(MEN_DIR + "group_results.json"));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private IList<Match> GetMenMatchForCountry(string code)
        {
            try
            {
                return Match.FromJson(File.ReadAllText(MEN_DIR + "matches.json")).Where(m => m.HomeTeam.Code == code || m.AwayTeam.Code == code).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private IList<Team> GetMenTeams()
        {
            try
            {
                return Team.FromJson(File.ReadAllText(MEN_DIR + "teams.json"));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private IList<TeamResult> GetMenTeamResults()
        {
            try
            {
                return TeamResult.FromJson(File.ReadAllText(MEN_DIR + "results.json"));
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private IList<GroupResult> GetWomenGroupResults()
        {
            try
            {
                return GroupResult.FromJson(File.ReadAllText(WOMEN_DIR + "group_results.json"));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private IList<Match> GetWomenMatchForCountry(string code)
        {
            try
            {
                return Match.FromJson(File.ReadAllText(WOMEN_DIR + "matches.json")).Where(m => m.HomeTeam.Code == code || m.AwayTeam.Code == code).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private IList<Team> GetWomenTeams()
        {
            try
            {
                return Team.FromJson(File.ReadAllText(WOMEN_DIR + "teams.json"));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private IList<TeamResult> GetWomenTeamResults()
        {
            try
            {
                return TeamResult.FromJson(File.ReadAllText(WOMEN_DIR + "results.json"));
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        
    }
}
