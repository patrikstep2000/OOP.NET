using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public partial class Player
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("favourite")]
        public bool IsFavourite { get; set; }

        [JsonProperty("no_of_goals")]
        public int NumberOfGoals { get; set; }

        [JsonProperty("no_of_yellow_cards")]
        public int NumberOfYellowCards { get; set; }

    }

    public partial class Player
    {
        public static Player FromJson(string json) => JsonConvert.DeserializeObject<Player>(json);

        public string Serialize() => JsonConvert.SerializeObject(this);

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name &&
                   Captain == player.Captain &&
                   ShirtNumber == player.ShirtNumber &&
                   Position == player.Position;
        }

        public override int GetHashCode()
        {
            int hashCode = -996206630;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Captain.GetHashCode();
            hashCode = hashCode * -1521134295 + ShirtNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Position);
            return hashCode;
        }

        public string ToPrintStringGoals() => $"{Name}, Number of goals: {NumberOfGoals}";
        public string ToPrintStringYellowCards() => $"{Name}, Number of yellow cards: {NumberOfYellowCards}";
    }
}
