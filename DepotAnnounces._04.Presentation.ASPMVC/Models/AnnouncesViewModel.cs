using DepotAnnounces._03.Presentation.API.Dtos;

namespace DepotAnnounces._04.Presentation.ASPMVC.Models
{
    public class AnnouncesViewModel
    {
        public IEnumerable<AnnounceForDisplayDto>? Announces { get; set; }
        public string SearchTerm { get; set; }
    }
}
