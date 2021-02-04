using System.Collections.Generic;

namespace CheapAwesome.API.Models
{
    public class HotelInfo
    {
        public HotelInfo()
        {
            Rates = new List<HotelRate>();
        }

        public int PropertyId { get; set; }

        public string Name { get; set; }

        public int GeoId { get; set; }

        public int Rating { get; set; }

        public List<HotelRate> Rates { get; set; }
    }
}
