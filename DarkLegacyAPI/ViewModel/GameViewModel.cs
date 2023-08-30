namespace DarkLegacy.API.ViewModel
{
    public class GameViewModel
    {
        public int IdGame { get; set; }
        public string NmGame { get; set; } = string.Empty;
        public int LaunchYear { get; set; }
        public int Score { get; set; }
        public string DsGenre { get; set; } = string.Empty;
    }
}