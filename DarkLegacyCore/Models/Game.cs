using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DarkLegacy.Core.Models
{
    public class Game
    {
        [Key]
        public int IdGame { get; set; }
        public string NmGame { get; set; } = string.Empty;

        [JsonIgnore]
        public bool FlEnabled { get; set; }

        [ForeignKey("Genre")]
        public int IdGenre { get; set; }
        public int LaunchYear { get; set; }
        public int Score { get; set; }

        [JsonIgnore]
        public Genre? Genre { get; set; }
    }
}
