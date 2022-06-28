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
    public enum Resolution
    {
        Undefined, Fullscreen, Large, Medium, Small
    }

    public class AppSettings
    {
        [JsonProperty("world_cup_type")]
        public string WorldCup { get; set; }

        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("res", NullValueHandling = NullValueHandling.Ignore)]
        public Resolution Resolution { get; set; }

        [JsonProperty("fav_team")]
        public Team FavouriteTeam { get; set; }

        [JsonProperty("fav_players")]
        public List<Player> FavouritePlayers { get; set; }

        public static AppSettings FromJson(string json) => JsonConvert.DeserializeObject<AppSettings>(json);

        public string Serialize() => JsonConvert.SerializeObject(this, Converter.Settings);

        
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ResolutionConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ResolutionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Resolution) || t == typeof(Resolution?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "undefined":
                    return Resolution.Undefined;
                case "fullscreen":
                    return Resolution.Fullscreen;
                case "large":
                    return Resolution.Large;
                case "medium":
                    return Resolution.Medium;
                case "small":
                    return Resolution.Small;
            }
            throw new Exception("Cannot unmarshal type Resolution");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Resolution)untypedValue;
            switch (value)
            {
                case Resolution.Undefined:
                    serializer.Serialize(writer, "undefined");
                    return;
                case Resolution.Fullscreen:
                    serializer.Serialize(writer, "fullscreen");
                    return;
                case Resolution.Large:
                    serializer.Serialize(writer, "large");
                    return;
                case Resolution.Medium:
                    serializer.Serialize(writer, "medium");
                    return;
                case Resolution.Small:
                    serializer.Serialize(writer, "small");
                    return;
            }
            throw new Exception("Cannot marshal type Resolution");
        }

        public static readonly ResolutionConverter Singleton = new ResolutionConverter();
    }
}
