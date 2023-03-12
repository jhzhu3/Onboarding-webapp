using SortWasteVictoria_WebApp.Models;

namespace SortWasteVictoria_WebApp.JsonModels
{
    public class JsonBins
    {
        //public int BinId { get; set; }
        public string BinColour { get; set; }
        public string BinInfo { get; set; }
    }
    public class JsonGarbages
    {
        //public int GarbageId { get; set; }
        public string? GarbageName { get; set; }

        public int BinId { get; set; }
    }
}
