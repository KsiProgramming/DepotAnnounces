using DepotAnnounces._00.Core.Entities;

namespace DepotAnnounces._02.Application.Repositories
{
    public interface ILocationRepository
    {
        Task AddAddress(AddressEntity aAddress);
        Task AddCity(CityEntity aCity);
        void Dispose();
        Task<AddressEntity> GetAddress(string aId);
        Task<IEnumerable<AddressEntity>> GetAddresses();
        Task<IEnumerable<CityEntity>> GetCities();
        Task<CityEntity> GetCity(int aId);
        Task<bool> isAddressExists(string aId);
        Task<bool> isCityExists(int aId);
        Task<bool> SaveChangesAsync();
    }
}