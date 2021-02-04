using System.Collections.Generic;

namespace CheapAwesome.Providers.BargainsForCouples.Models
{
    public class HotelInfo
    {
        public HotelInfo()
        {
            Rates = new List<HotelRate>();
        }

        public Hotel Hotel { get; set; }

        public List<HotelRate> Rates { get; set; }
    }
}
