using DarkLegacyAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DarkLegacyAPI.ViewModel
{
    public class JogosViewModel
    {
        public int IdJogo { get; set; }
        public string NmJogo { get; set; }
        public int AnoLancamento { get; set; }
        public int Nota { get; set; }
        public string? DsGenero { get; set; }

    }
}
