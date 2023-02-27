using DepotAnnounces._02.Application.Models.SeLoger;
using DepotAnnounces._02.Application.Models;
using DepotAnnounces._02.Application.Services.SeLogerAddress;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DepotAnnounces._02.Application.Models.APIAddresseGouv;
using DepotAnnounces._02.Application.Services.Interfaces;
using System.Globalization;

namespace DepotAnnounces._02.Application.Services.GouvAPIAddress
{
    public class GouvAPIAddressService: IAddressDataService
    {
        private HttpClient _Client;
        private readonly ILogger<GouvAPIAddressService> _Logger;

        public GouvAPIAddressService(HttpClient aHttpClient, ILogger<GouvAPIAddressService> aLogger)
        {
            _Logger = aLogger ?? throw new ArgumentNullException(nameof(aLogger));
            _Client = aHttpClient ?? throw new ArgumentNullException(nameof(aHttpClient));
            _Client.BaseAddress = new Uri("https://api-adresse.data.gouv.fr/search/");
            _Client.Timeout = new TimeSpan(0, 0, 30);
            _Client.DefaultRequestHeaders.Clear();
        }
        public async Task<AddressData> GetAddressData(string aSearchKey, CancellationToken aCancellationToken)
        {
            _Logger.LogInformation($"Get Address Data for the following key: {aSearchKey} was requested");
            var request = new HttpRequestMessage(HttpMethod.Get, $"?q={aSearchKey}");
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            using (var response = await _Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, aCancellationToken))
            {
                response.EnsureSuccessStatusCode();
                var de = (await response.Content.ReadAsStreamAsync());
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var adresses = await JsonSerializer.DeserializeAsync<APIAddresseGouv>(de, options);
                var address = adresses!.features!.FirstOrDefault();
                return address == null ?
                                        new AddressData()
                                        :
                                        new AddressData()
                                        {
                                            ZipCode = int.Parse(address!.properties!.postcode!),
                                            CityName = address?.properties!.city,
                                            Label = address?.properties!.label,
                                            Latitude = Convert.ToString(address!.geometry!.coordinates![1], CultureInfo.InvariantCulture),
                                            Longitude = Convert.ToString(address!.geometry!.coordinates![0], CultureInfo.InvariantCulture),
                                            RegionName = address.properties.context.Split(',')[2]??"",
                                            StateName = address.properties.context.Split(',')[1] ?? "", 
                                        };


            }
        }
    }
}
