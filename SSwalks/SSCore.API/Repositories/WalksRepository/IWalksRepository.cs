using SSCore.API.Models.Domain;

namespace SSCore.API.Repositories.WalksRepository
{
    public interface IWalksRepository
    {
        public Task<IEnumerable<Walk>> GetWalksAsync();
        public Task<Walk?> GetWalkAsync(Guid Id);

        Task<Walk> AddAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid Id, Walk walk);

        Task<Walk?> DeleteAsync(Guid Id);
    }
}
