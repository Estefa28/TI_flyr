using Newshore.DataAccess.Enums;
using Newshore.DataAccess.Models;

namespace Newshore.DataAccess.Interfaces
{
    public interface INewshoreAPI
    {
        Task<List<FlightRecord>> GetFlightsAsync(RouteType routeType);
    }
}
