namespace SortWasteVictoria_WebApp.Models
{
    public class Garbage
    {
        public int GarbageId { get; set; }
        public string? GarbageName { get; set; }

        public int BinId { get; set; }
        public Bin? Bin { get; set; }
    }
}
