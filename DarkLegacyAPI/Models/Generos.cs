using System.ComponentModel.DataAnnotations;

namespace DarkLegacyAPI.Models
{
    public class Generos
    {
        [Key]
        public int IdGenero { get; set; }
        public string DsGenero { get; set; }
    }
}
