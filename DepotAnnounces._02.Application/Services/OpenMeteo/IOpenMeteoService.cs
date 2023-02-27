using DepotAnnounces._02.Application.Models.OpenMeteo;

namespace DepotAnnounces._02.Application.Services.OpenMeteo
{
    public interface IOpenMeteoService
    {
        Task<Weather> GetPositionWeather(string aLatitude, string aLongitude, CancellationToken aCancellationToken);
    }
}