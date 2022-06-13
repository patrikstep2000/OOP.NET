using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public partial class GroupResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("letter")]
        public string Letter { get; set; }

        [JsonProperty("ordered_teams")]
        public List<TeamResult> OrderedTeamResults { get; set; }
    }

    public partial class GroupResult
    {
        public static IList<GroupResult> FromJson(string json) => JsonConvert.DeserializeObject<IList<GroupResult>>(json, GroupResultConverter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<GroupResult> self) => JsonConvert.SerializeObject(self, GroupResultConverter.Settings);
    }

    internal static class GroupResultConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
