using CheapAwesome.API.Models;
using CheapAwesome.API.Services.Interfaces;
using CheapAwesome.Providers.BargainsForCouples.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesome.API.Services
{
    public class ValentinesBargainsService : IValentinesBargainsService
    {
        private const string NightRateType = "PerNight";
        private readonly IBargainsForCouplesProvider _provider;

        public ValentinesBargainsService(IBargainsForCouplesProvider provider)
        {
            _provider = provider;
        }

        public async Task<List<HotelInfo>> Find(int destinationId, int nights)
        {
            var aggregatedHotels = await _provider.Find(destinationId, nights);

            var hotels = aggregatedHotels.Select(x => new HotelInfo
            {
                Name = x.Hotel.Name,
                Rating = x.Hotel.Rating,
                PropertyId = x.Hotel.PropertyId,
                GeoId = x.Hotel.GeoId,
                Rates = GetBestRateByBoradType(x.Rates, nights)
            }).ToList();
            return hotels;
        }

        private List<HotelRate> GetBestRateByBoradType(List<Providers.BargainsForCouples.Models.HotelRate> rates, int nights)
        {
            var stayRates = rates.Select(r => new HotelRate { BoardType = r.BoardType, Price = GetFinalPrice(r, nights) });

            var bestRates = stayRates
                .OrderBy(r => r.Price)
                .GroupBy(r => r.BoardType)
                .Select(g => g.First())
                .ToList();
            return bestRates;
        }

        private double GetFinalPrice(Providers.BargainsForCouples.Models.HotelRate hotelRate, int nights)
        {
            if (hotelRate.RateType == NightRateType)
            {
                return hotelRate.Value * nights;
            }

            return hotelRate.Value;
        }
    }
}
