using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repo;

namespace DAL.Models
{
    public partial class Team
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public string AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        public override string ToString()
        {
            return $"{Country.ToUpper()} ({FifaCode.ToUpper()})";
        }
    }

    public partial class Team
    {
        public static IList<Team> FromJson(string json) => JsonConvert.DeserializeObject<List<Team>>(json);
    }
}
