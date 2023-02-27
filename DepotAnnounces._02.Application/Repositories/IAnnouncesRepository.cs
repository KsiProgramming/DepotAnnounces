using DepotAnnounces._00.Core.Entities;

namespace DepotAnnounces._02.Application.Repositories
{
    public interface IAnnouncesRepository
    {
        Task<Guid> Add(AnnounceEntity aAnnounce);        
        void Dispose();
        Task<AnnounceEntity> GetByIdAsync(Guid aId);
        Task<IEnumerable<AnnounceEntity>> GetAllAsync();
        Task<bool> SaveChangesAsync();
        void Update(AnnounceEntity aAnnounce);
        AnnounceEntity Delete(Guid aId);
    }
}