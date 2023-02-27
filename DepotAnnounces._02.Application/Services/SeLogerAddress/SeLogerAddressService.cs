using DepotAnnounces._02.Application.Models;
using DepotAnnounces._02.Application.Models.SeLoger;
using DepotAnnounces._02.Application.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepotAnnounces._02.Application.Services.SeLogerAddress
{
    public class SeLogerAddressService : IAddressDataService
    {
        private HttpClient _Client;
        private readonly ILogger<SeLogerAddressService> _Logger;

        public SeLogerAddressService(HttpClient aHttpClient, ILogger<SeLogerAddressService> aLogger)
        {
            _Logger = aLogger ?? throw new ArgumentNullException(nameof(aLogger));
            _Client = aHttpClient ?? throw new ArgumentNullException(nameof(aHttpClient));
            _Client.BaseAddress = new Uri("https://autocomplete.svc.groupe-seloger.com/api/v3.0/auto/complete/fr/");
            _Client.Timeout = new TimeSpan(0, 0, 30);
            _Client.DefaultRequestHeaders.Clear();            
        }
        public async Task<AddressData> GetAddressData(string aSearchKey, CancellationToken aCancellationToken)
        {
            //_Logger.LogInformation("Get All Product requested via HttpClient");
            string url = "Address?text="+aSearchKey;
            var request = new HttpRequestMessage(HttpMethod.Get, url.Trim());
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            using (var response = await _Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, aCancellationToken))
            {
                response.EnsureSuccessStatusCode();
                var de = (await response.Content.ReadAsStreamAsync());
                var adresses = await JsonSerializer.DeserializeAsync<SeLogerResponse>(de);
                var address = adresses!.Addresses!.FirstOrDefault();
                return address == null ?
                                        new AddressData()
                                        :
                                        new AddressData()
                                        {
                                            ZipCode = int.Parse(address.Params.PostalCode),
                                            CityName = address.Params.City,
                                            Label = address.Display,
                                            Latitude = address.Params.Latitude,
                                            Longitude = address.Params.Longitude
                                        };


            }
        }
    }
}
