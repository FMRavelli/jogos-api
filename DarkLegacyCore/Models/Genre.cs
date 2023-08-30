using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DarkLegacy.Core.Models
{
    public class Genre
    {
        [Key]
        public int IdGenre { get; set; }
        public string DsGenre { get; set; } = string.Empty;

        [JsonIgnore]
        public bool FlEnabled { get; set; }
    }
}