using AutoMapper;
using DepotAnnounces._00.Core.Entities;
using DepotAnnounces._02.Application.Repositories;
using DepotAnnounces._02.Application.Services.Interfaces;
using DepotAnnounces._02.Application.Services.OpenMeteo;
using DepotAnnounces._03.Presentation.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DepotAnnounces._03.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncesController : ControllerBase
    {
        private readonly IAnnouncesRepository _AnnouncesRepository;
        private readonly ILogger _Logger;
        private readonly IMapper _Mapper;
        private readonly IOpenMeteoService _MeteoService;
        private readonly IAddressDataService _AddressDataService;
        private readonly ILocationRepository _LocationRepository;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();


        public AnnouncesController(IAnnouncesRepository aAnnouncesRepository,
                                    ILogger<AnnouncesController> aLogger,
                                    IMapper aMapper,
                                    IOpenMeteoService aMeteoService,
                                    IAddressDataService aAddressDataService,
                                    ILocationRepository aLocationRepository)
        {
            _AnnouncesRepository = aAnnouncesRepository;
            _Logger = aLogger;
            _Mapper = aMapper;
            _MeteoService = aMeteoService;
            _AddressDataService = aAddressDataService;
            _LocationRepository = aLocationRepository;

        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                _Logger.LogInformation($"Get Announce by id was requested Id:{id}");
                var announce = await _AnnouncesRepository.GetByIdAsync(id);
                if (announce == null) { return NotFound(); }
                if (!announce.IsPublished) { return NotFound(); }
                var address = await _LocationRepository.GetAddress(announce!.Location!);
                var temperature = (await _MeteoService.GetPositionWeather(address!.Latitude!, address!.Longitude!, _cancellationTokenSource.Token))!.current_weather!.temperature!;
                var announceDisp = _Mapper.Map<AnnounceForDisplayDto>(announce);
                announceDisp.Temperature = $"{temperature}°C";

                return Ok(announceDisp);

            }
            catch (Exception ex)
            {
                _Logger.LogError($"Exception while getting announce by id {id} exception: {ex}");
                return StatusCode(500, "Something went wrong");
            }

        }
        [HttpGet]
        [Route("Announces")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var announces = await _AnnouncesRepository.GetAllAsync();

                List<AnnounceForDisplayDto> announceForDisplayDtos = new List<AnnounceForDisplayDto>();
                foreach (var announce in announces.Where(a => a.IsPublished))
                {
                    //var address = await _AddressDataService.GetAddressData(announce!.Location!, _cancellationTokenSource.Token);
                    var address = await _LocationRepository.GetAddress(announce!.Location!);
                    var temperature = (await _MeteoService.GetPositionWeather(address!.Latitude!, address!.Longitude!, _cancellationTokenSource.Token))!.current_weather!.temperature!;
                    var announceDisp = _Mapper.Map<AnnounceForDisplayDto>(announce);
                    announceDisp.Temperature = $"{temperature}°C";
                    announceForDisplayDtos.Add(announceDisp);

                }
                return Ok(announceForDisplayDtos);
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Exception while getting all anounces exception: {ex}");
                return StatusCode(500, "Something went wrong");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AnnounceForCreation aAnnounce)
        {
            try
            {
                if (aAnnounce == null) { throw new ArgumentNullException(nameof(aAnnounce)); }
                var addressData = await _AddressDataService.GetAddressData(aAnnounce.Location, _cancellationTokenSource.Token);
                if (addressData.Label == null) { return NotFound("La localisation de bien est introuvable, Essayez avec le code postal."); }
                var isAddressDBExits = await _LocationRepository.isAddressExists(addressData.Label.Trim());
                var iscityDBExits = await _LocationRepository.isCityExists(addressData.ZipCode);
                if (!isAddressDBExits)
                {
                    await _LocationRepository.AddAddress(new AddressEntity()
                    {
                        Id = addressData.Label.Trim(),
                        Latitude = addressData.Latitude,
                        Longitude = addressData.Longitude,
                        Name = addressData.Label,
                        ZipCode = addressData.ZipCode,

                    });
                };
                if (!iscityDBExits)
                {
                    await _LocationRepository.AddCity(new CityEntity()
                    {
                        Name = addressData.CityName,
                        ZipCode = addressData.ZipCode
                    });
                }


                var announce = _Mapper.Map<AnnounceEntity>(aAnnounce);
                //announce = new AnnounceEntity()
                //{
                announce.Id = Guid.NewGuid();                
                announce.ZipCode = addressData.ZipCode;
                announce.AddressId = addressData.Label.Trim();
                announce.IsPublished = false;
                announce.Location = addressData.Label;


                //};
                var announceid = await _AnnouncesRepository.Add(announce);
                return Ok($"Une nouvelle anounce a été bien crée avec l'id: {announceid}.");
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Exception while Adding announce: {ex}");
                return StatusCode(500, "Something went wrong");
            }

        }
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id)
        {
            try
            {
                _Logger.LogInformation($"Put Announce was requested, product Id:{id}.");

                var announce = await _AnnouncesRepository.GetByIdAsync(id);
                announce.IsPublished = true;
                _AnnouncesRepository.Update(announce);

                await _AnnouncesRepository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Exception while updating announce: {ex}");
                return StatusCode(500, "Something went wrong");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                _Logger.LogInformation($"Delete Announce with Id:{id} was requested.");
                var announce = await _AnnouncesRepository.GetByIdAsync(id);
                if (announce == null)
                {
                    return NotFound();
                }
                _AnnouncesRepository.Delete(id);
                await _AnnouncesRepository.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                _Logger.LogError($"Exception while deleting announce id:{id}, exception: {ex}");
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
