using DepotAnnounces._02.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepotAnnounces._02.Application.Services.Interfaces
{
    public interface IAddressDataService
    {
        Task<AddressData> GetAddressData(string aSearchKey, CancellationToken aCancellationToken);
    }
}
