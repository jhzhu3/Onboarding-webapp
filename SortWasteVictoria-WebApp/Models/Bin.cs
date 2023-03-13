namespace SortWasteVictoria_WebApp.Models
{
    public class Bin
    {
        public int BinId { get; set; }
        public string? BinColour { get; set; }
        public string? BinInfo { get; set; }

        public ICollection<Garbage> garbages { get; set; }

    }
}
