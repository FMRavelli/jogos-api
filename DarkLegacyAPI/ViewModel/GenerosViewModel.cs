using System.ComponentModel.DataAnnotations;

namespace DarkLegacyAPI.ViewModel
{
    public record GenerosViewModel
    {
        public int IdGenero { get; set; }
        public string DsGenero { get; set; }
    }
}
