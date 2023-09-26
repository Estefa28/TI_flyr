using Newshore.Business.Models;

namespace Newshore.Business.Interfaces
{
    public interface IFlightManager
    {
        Task<Journey> GetJourneyAsync(string origin, string destination);  
    }
}
