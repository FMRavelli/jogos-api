using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DarkLegacyAPI.Models
{
    public class Jogos
    {
        [Key]
        public int IdJogo { get; set; }
        public string NmJogo { get; set; }

        [ForeignKey("Genero")]
        public int IdGenero { get; set; }
        public int AnoLancamento { get; set; }
        public int Nota { get; set; }

        public Generos Genero { get; set; }
    }
}
