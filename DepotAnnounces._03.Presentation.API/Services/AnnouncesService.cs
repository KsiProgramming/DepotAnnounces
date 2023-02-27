using DepotAnnounces._03.Presentation.API.Dtos;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DepotAnnounces._03.Presentation.API.Services
{
    public class AnnouncesService : IAnnouncesService
    {
        private HttpClient _Client;
        private readonly ILogger<AnnouncesService> _Logger;


        public AnnouncesService(HttpClient aHttpClient, ILogger<AnnouncesService> aLogger)
        {
            _Logger = aLogger ?? throw new ArgumentNullException(nameof(aLogger));
            _Client = aHttpClient ?? throw new ArgumentNullException(nameof(aHttpClient));
            _Client.BaseAddress = new Uri("https://localhost:7160/api/Announces/");
            _Client.Timeout = new TimeSpan(0, 0, 30);
            _Client.DefaultRequestHeaders.Clear();
        }
        public async Task<IEnumerable<AnnounceForDisplayDto>> GetAnnounces(CancellationToken aCancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "Announces");
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            using (var response = await _Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, aCancellationToken))
            {
                response.EnsureSuccessStatusCode();
                var de = (await response.Content.ReadAsStreamAsync());
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                return await JsonSerializer.DeserializeAsync<IEnumerable<AnnounceForDisplayDto>>(de, options: options);


            }
        }
    }
}
