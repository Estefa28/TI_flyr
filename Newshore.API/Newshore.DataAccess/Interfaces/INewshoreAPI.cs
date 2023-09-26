using Newshore.DataAccess.Enums;
using Newshore.Domain.Models;

namespace Newshore.DataAccess.Interfaces
{
    public interface INewshoreAPI
    {
        Task<List<FlightRecord>> GetFlightsAsync(RouteType routeType);
    }
}
