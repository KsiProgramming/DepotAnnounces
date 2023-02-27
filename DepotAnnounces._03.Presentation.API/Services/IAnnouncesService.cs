using DepotAnnounces._03.Presentation.API.Dtos;

namespace DepotAnnounces._03.Presentation.API.Services
{
    public interface IAnnouncesService
    {
        Task<IEnumerable<AnnounceForDisplayDto>> GetAnnounces(CancellationToken aCancellationToken);
    }
}