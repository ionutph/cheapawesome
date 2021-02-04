using CheapAwesome.Providers.BargainsForCouples.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheapAwesome.Providers.BargainsForCouples.Services.Interfaces
{
    public interface IBargainsForCouplesProvider
    {
        Task<List<HotelInfo>> Find(int destinationId, int nights);
    }
}
