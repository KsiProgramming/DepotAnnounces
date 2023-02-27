using DepotAnnounces._00.Core.Entities;
using DepotAnnounces._01.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepotAnnounces._02.Application.Repositories
{
    public class LocationRepository : IDisposable, ILocationRepository
    {
        private AnnouncesContext _Db;
        private bool _IsDisposed = false;
        public LocationRepository(AnnouncesContext aDb)
        {
            _Db = aDb;
        }

        public async Task<bool> isCityExists(int aId)
        {
            return await _Db.Cities.AnyAsync(c => c.ZipCode == aId);
        }
        public async Task<bool> isAddressExists(string aId)
        {
            return await _Db.Addresses.AnyAsync(a => a.Id == aId);
        }

        public async Task<AddressEntity> GetAddress(string aId)
        {
            return await _Db.Addresses.FindAsync(aId);
        }
        public async Task<CityEntity> GetCity(int aId)
        {
            return await _Db.Cities.FindAsync(aId);
        }
        public async Task<IEnumerable<CityEntity>> GetCities()
        {
            return await _Db.Cities.ToListAsync();
        }
        public async Task<IEnumerable<AddressEntity>> GetAddresses()
        {
            return await _Db.Addresses.ToListAsync();
        }
        public async Task AddCity(CityEntity aCity)
        {
            if (aCity == null)
            {
                throw new ArgumentNullException(nameof(aCity));
            }
            await _Db.Cities.AddAsync(aCity);
            await SaveChangesAsync();
        }
        public async Task AddAddress(AddressEntity aAddress)
        {
            if (aAddress == null)
            {
                throw new ArgumentNullException(nameof(aAddress));
            }
            await _Db.Addresses.AddAsync(aAddress);
            await SaveChangesAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _Db.SaveChangesAsync() > 0;
        }
        ~LocationRepository()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {

            if (!_IsDisposed & disposing & _Db != null)
            {
                _Db?.Dispose();
                _Db = null;

            }
            _IsDisposed = true;
        }
    }
}
