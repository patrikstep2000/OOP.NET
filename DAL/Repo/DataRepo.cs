using DAL.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public partial class DataRepo : IRepo
    {
        private const string WOMEN_BASE_URI = "https://worldcup.sfg.io/";
        private const string MEN_BASE_URI = "https://world-cup-json-2018.herokuapp.com/";

        private const string WOMEN_BASE_FAIL_URI = "http://worldcup.sfg.io/";
        private const string MEN_BASE_FAIL_URI = "http://world-cup-json-2018.herokuapp.com/";

        private static string PLAYER_IMAGE_BASE_DIR = RepoFactory.SETTINGS_DIR + @"\PlayerImages\";

        private readonly RestClient restClient = new RestClient();

        private readonly FileRepo backupRepo = new FileRepo();

        private const int TIMEOUT = 5000;
    }

    public partial class DataRepo : IRepo
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
            return worldCup == "men" ? GetMenMatchForCountry(worldCup, code) : GetWomenMatchForCountry(worldCup, code);
        }
        public IList<Team> GetTeams(string worldCup)
        {
            return worldCup == "men" ? GetMenTeams(worldCup) : GetWomenTeams(worldCup);
        }
        public IList<TeamResult> GetTeamResults(string worldCup)
        {
            return worldCup == "men" ? GetMenTeamResults(worldCup) : GetWomenTeamResults(worldCup);
        }
        public IList<GroupResult> GetGroupResults(string worldCup)
        {
            return worldCup == "men" ? GetMenGroupResults(worldCup) : GetWomenGroupResults(worldCup);
        }




        private IList<GroupResult> GetMenGroupResults(string worldCup)
        {
            var request = new RestRequest(MEN_BASE_URI + "teams/group_results/");
            try
            {
                var response = restClient.GetAsync(request);
                
                if (response.Wait(TIMEOUT) && response.Result.Content != null)
                {
                    return GroupResult.FromJson(response.Result.Content);
                }
                else
                {
                    request = new RestRequest(MEN_BASE_FAIL_URI + "teams/group_results/");
                    var responseS = restClient.GetAsync(request);
                    if (responseS.Wait(TIMEOUT) && responseS.Result.Content != null)
                    {
                        return GroupResult.FromJson(responseS.Result.Content);
                    }
                    else
                    {
                        return backupRepo.GetGroupResults(worldCup);
                    }
                }
            }
            catch (Exception)
            {
                return backupRepo.GetGroupResults(worldCup);
            }
        }
        private IList<Match> GetMenMatchForCountry(string worldCup, string code)
        {
            var request = new RestRequest(MEN_BASE_URI + "matches/country?fifa_code=" + code);
            try
            {
                var response = restClient.GetAsync(request);
                if (response.Wait(TIMEOUT) && response.Result.Content != null)
                {
                    return Match.FromJson(response.Result.Content);
                }
                else
                {
                    request = new RestRequest(MEN_BASE_FAIL_URI + "matches/country?fifa_code=" + code);
                    var responseS = restClient.GetAsync(request);
                    if (responseS.Wait(TIMEOUT) && responseS.Result.Content != null)
                    {
                        return Match.FromJson(responseS.Result.Content);
                    }
                    else
                    {
                        return backupRepo.GetMatchForCountry(worldCup, code);
                    }
                }
            }
            catch (Exception)
            {
                return backupRepo.GetMatchForCountry(worldCup, code);
            }
        }
        private IList<TeamResult> GetMenTeamResults(string worldCup)
        {
            var request = new RestRequest(MEN_BASE_URI + "teams/results/");
            try
            {
                var response = restClient.GetAsync(request);
                if (response.Wait(TIMEOUT) && response.Result.Content != null)
                {
                    return TeamResult.FromJson(response.Result.Content);
                }
                else
                {
                    request = new RestRequest(MEN_BASE_FAIL_URI + "teams/result/s");
                    var responseS = restClient.GetAsync(request);
                    if (responseS.Wait(TIMEOUT) && responseS.Result.Content != null)
                    {
                        return TeamResult.FromJson(responseS.Result.Content);
                    }
                    else
                    {
                        return backupRepo.GetTeamResults(worldCup);
                    }
                }
            }
            catch (Exception)
            {
                return backupRepo.GetTeamResults(worldCup);
            }
        }
        private IList<Team> GetMenTeams(string worldCup)
        {
            var request = new RestRequest(MEN_BASE_URI + "teams/");
            try
            {
                var response = restClient.GetAsync(request);
                if (response.Wait(TIMEOUT) && response.Result.Content != null)
                {
                    return Team.FromJson(response.Result.Content);
                }
                else
                {
                    request = new RestRequest(MEN_BASE_FAIL_URI + "teams/");
                    var responseS = restClient.GetAsync(request);
                    if (responseS.Wait(TIMEOUT) && responseS.Result.Content != null)
                    {
                        return Team.FromJson(responseS.Result.Content);
                    }
                    else
                    {
                        return backupRepo.GetTeams(worldCup);
                    }
                }
            }
            catch (Exception)
            {
                return backupRepo.GetTeams(worldCup);
            }
        }


        private IList<GroupResult> GetWomenGroupResults(string worldCup)
        {
            var request = new RestRequest(WOMEN_BASE_URI + "teams/group_results/");
            try
            {
                var response = restClient.GetAsync(request);
                if (response.Wait(TIMEOUT) && response.Result.Content != null)
                {
                    return GroupResult.FromJson(response.Result.Content);
                }
                else
                {
                    request = new RestRequest(WOMEN_BASE_FAIL_URI + "teams/group_results/");
                    var responseS = restClient.GetAsync(request);
                    if (responseS.Wait(TIMEOUT) && responseS.Result.Content != null)
                    {
                        return GroupResult.FromJson(responseS.Result.Content);
                    }
                    else
                    {
                        return backupRepo.GetGroupResults(worldCup);
                    }
                }
            }
            catch (Exception)
            {
                return backupRepo.GetGroupResults(worldCup);
            }
        }
        private IList<Match> GetWomenMatchForCountry(string worldCup, string code)
        {
            var request = new RestRequest(WOMEN_BASE_URI + "matches/country?fifa_code=" + code);
            try
            {
                var response = restClient.GetAsync(request);
                if (response.Wait(TIMEOUT) && response.Result.Content != null)
                {
                    return Match.FromJson(response.Result.Content);
                }
                else
                {
                    request = new RestRequest(WOMEN_BASE_FAIL_URI + "matches/country?fifa_code=" + code);
                    var responseS = restClient.GetAsync(request);
                    if (responseS.Wait(TIMEOUT) && responseS.Result.Content != null)
                    {
                        return Match.FromJson(responseS.Result.Content);
                    }
                    else
                    {
                        return backupRepo.GetMatchForCountry(worldCup, code);
                    }
                }
            }
            catch (Exception)
            {
                return backupRepo.GetMatchForCountry(worldCup, code);
            }
        }
        private IList<TeamResult> GetWomenTeamResults(string worldCup)
        {
            var request = new RestRequest(WOMEN_BASE_URI + "teams/results/");
            try
            {
                var response = restClient.GetAsync(request);
                if (response.Wait(TIMEOUT) && response.Result.Content != null)
                {
                    return TeamResult.FromJson(response.Result.Content);
                }
                else
                {
                    request = new RestRequest(WOMEN_BASE_FAIL_URI + "teams/results/");
                    var responseS = restClient.GetAsync(request);
                    if (responseS.Wait(TIMEOUT) && responseS.Result.Content != null)
                    {
                        return TeamResult.FromJson(responseS.Result.Content);
                    }
                    else
                    {
                        return backupRepo.GetTeamResults(worldCup);
                    }
                }
            }
            catch (Exception)
            {
                return backupRepo.GetTeamResults(worldCup);
            }
        }
        private IList<Team> GetWomenTeams(string worldCup)
        {
            var request = new RestRequest(WOMEN_BASE_URI + "teams/");
            try
            {
                var response = restClient.GetAsync(request);
                if (response.Wait(TIMEOUT) && response.Result.Content != null)
                {
                    return Team.FromJson(response.Result.Content);
                }
                else
                {
                    request = new RestRequest(WOMEN_BASE_FAIL_URI + "teams/");
                    var responseS = restClient.GetAsync(request);
                    if (responseS.Wait(TIMEOUT) && responseS.Result.Content != null)
                    {
                        return Team.FromJson(responseS.Result.Content);
                    }
                    else
                    {
                        return backupRepo.GetTeams(worldCup);
                    }
                }
            }
            catch (Exception)
            {
                return backupRepo.GetTeams(worldCup);
            }
        }


        public Image GetPlayerPicture(Player player)
        {
            try
            {

                if (File.Exists(PLAYER_IMAGE_BASE_DIR + player.Name + ".png"))
                    return Image.FromFile(PLAYER_IMAGE_BASE_DIR + player.Name + ".png");
                else
                    return null;
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
    }
}
