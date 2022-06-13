using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using System.IO;

namespace DAL.Models
{
    public class Config
    {
        public enum Source
        {
            API,
            JSON
        }

        [JsonProperty("source")]
        [JsonConverter(typeof(SourceConverter))]
        public Source DataSource { get; }

        public static Config FromJson(string json) => JsonConvert.DeserializeObject<Config>(json, ConfigConverter.Settings);

        internal static class ConfigConverter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new SourceConverter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class SourceConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Source) || t == typeof(Source?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "API":
                        return Source.API;
                    case "JSON":
                        return Source.JSON;
                }
                throw new Exception("Cannot unmarshal type Source");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Source)untypedValue;
                switch (value)
                {
                    case Source.API:
                        serializer.Serialize(writer, "API");
                        return;
                    case Source.JSON:
                        serializer.Serialize(writer, "JSON");
                        return;
                }
                throw new Exception("Cannot marshal type Source");
            }

            public static readonly SourceConverter Singleton = new SourceConverter();
        }
    }
}