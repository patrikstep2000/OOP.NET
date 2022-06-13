using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AppSettings
    {
        [JsonProperty("world_cup_type")]
        public string WorldCup { get; set; }

        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("res_width")]
        public int ResolutionWidth { get; set; }

        [JsonProperty("res_height")]
        public int ResolutionHeight { get; set; }

        [JsonProperty("fav_team")]
        public Team FavouriteTeam { get; set; }

        [JsonProperty("fav_players")]
        public List<Player> FavouritePlayers { get; set; }

        public static AppSettings FromJson(string json) => JsonConvert.DeserializeObject<AppSettings>(json);

        public string Serialize() => JsonConvert.SerializeObject(this);
    }
}
