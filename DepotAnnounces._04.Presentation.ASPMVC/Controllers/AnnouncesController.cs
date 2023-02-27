using DepotAnnounces._03.Presentation.API.Services;
using DepotAnnounces._04.Presentation.ASPMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepotAnnounces._04.Presentation.ASPMVC.Controllers
{
    public class AnnouncesController : Controller
    {
        private readonly ILogger<AnnouncesController> _Logger;
        private readonly IAnnouncesService _AnnouncesService;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public AnnouncesController(ILogger<AnnouncesController> aLogger, IAnnouncesService aAnnouncesService)
        {
            _AnnouncesService = aAnnouncesService;

            _Logger = aLogger ?? throw new ArgumentNullException(nameof(aLogger));
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchKey)
        {
            try
            {
                var de = await _AnnouncesService.GetAnnounces(_cancellationTokenSource.Token);
                var announceview = new AnnouncesViewModel();
                announceview.Announces = de;
                return View(announceview);
            }catch(Exception ex)
            {
                _Logger.LogError(ex.Message);
                return View(new AnnouncesViewModel());
            }

        }
    }
}
