using CheapAwesome.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheapAwesome.API.Services.Interfaces
{
    public interface IValentinesBargainsService
    {
        Task<List<HotelInfo>> Find(int destinationId, int nights);
    }
}
