using DepotAnnounces._00.Core.Entities;
using DepotAnnounces._01.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DepotAnnounces._02.Application.Repositories
{
    public class AnnouncesRepository : IDisposable, IAnnouncesRepository
    {
        private AnnouncesContext _Db;
        private bool _IsDisposed = false;
        public AnnouncesRepository(AnnouncesContext aDb)
        {
            _Db = aDb;

        }
        public async Task<AnnounceEntity> GetByIdAsync(Guid aId)
        {
            if (aId == Guid.Empty) throw new ArgumentException();
            return await _Db.Announces.FindAsync(aId);
        }

        public async Task<IEnumerable<AnnounceEntity>> GetAllAsync()
        {

            return await _Db.Announces.ToListAsync();
        }
        public async Task<Guid> Add(AnnounceEntity aAnnounce)
        {
            if (aAnnounce == null)
            {
                throw new ArgumentNullException(nameof(aAnnounce));
            }
            await _Db.AddAsync(aAnnounce);
            await SaveChangesAsync();
            return aAnnounce.Id;
        }
        public AnnounceEntity Delete(Guid aId)
        {
           
            var announce = _Db.Announces.Find(aId);
            if (announce != null)
            {
                _Db.Announces.Remove(announce);
            }
            return announce;
        }
        public void Update(AnnounceEntity aAnnounce)
        {
            _Db.Entry(aAnnounce).State = EntityState.Modified;
        }        
        public async Task<bool> SaveChangesAsync()
        {
            return await _Db.SaveChangesAsync() > 0;
        }
        ~AnnouncesRepository()
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
