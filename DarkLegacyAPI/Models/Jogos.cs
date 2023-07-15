using DarkLegacyAPI.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DarkLegacyAPI.Models
{
    public class Jogos
    {
        [Key]
        public int IdJogo { get; set; }
        public string NmJogo { get; set; }
        [JsonIgnore]
        public bool FlAtivo { get; set; }

        [ForeignKey("Genero")]
        public int IdGenero { get; set; }
        public int AnoLancamento { get; set; }
        public int Nota { get; set; }
        [JsonIgnore]
        public Generos? Genero { get; set; }


        public JogosViewModel MapToViewModel() 
        {
            return new JogosViewModel
            {
                IdJogo = IdJogo,
                NmJogo = NmJogo,
                AnoLancamento = AnoLancamento,
                DsGenero = Genero?.DsGenero,
                Nota = Nota
            };
        }

    }
}
