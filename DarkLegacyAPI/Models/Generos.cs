using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DarkLegacyAPI.Models
{
    public class Generos
    {
        [Key]
        public int IdGenero { get; set; }
        public string? DsGenero { get; set; }
        [JsonIgnore]
        public bool FlAtivo { get; set; }
    }
}
