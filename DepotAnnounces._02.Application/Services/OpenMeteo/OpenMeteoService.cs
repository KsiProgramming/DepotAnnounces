using DepotAnnounces._02.Application.Models.OpenMeteo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepotAnnounces._02.Application.Services.OpenMeteo
{
    public class OpenMeteoService : IOpenMeteoService
    {
        private HttpClient _Client;
        private readonly ILogger<OpenMeteoService> _Logger;


        public OpenMeteoService(HttpClient aHttpClient, ILogger<OpenMeteoService> aLogger)
        {
            _Logger = aLogger ?? throw new ArgumentNullException(nameof(_Logger));
            _Client = aHttpClient ?? throw new ArgumentNullException(nameof(aHttpClient));
            _Client.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
            _Client.Timeout = new TimeSpan(0, 0, 30);
            _Client.DefaultRequestHeaders.Clear();
        }
        public async Task<Weather> GetPositionWeather(string aLatitude, string aLongitude, CancellationToken aCancellationToken)
        {
            _Logger.LogInformation($"Get weather for the following location lat:{aLatitude},Long:{aLongitude} was requested.");
            var request = new HttpRequestMessage(HttpMethod.Get, $"forecast?latitude={aLatitude}&longitude={aLongitude}&current_weather=true");
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            using (var response = await _Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, aCancellationToken))
            {
                response.EnsureSuccessStatusCode();
                var de = (await response.Content.ReadAsStreamAsync());
                return await JsonSerializer.DeserializeAsync<Weather>(de);

            }
        }
    }
}
