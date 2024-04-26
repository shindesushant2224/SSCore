using SSCore.API.Models.Domain;

namespace SSCore.API.Repositories.DifficultyRepository
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();
        Task<WalkDifficulty?> GetAsync(Guid id);
        Task<WalkDifficulty> CreateAsync(WalkDifficulty walkDifficulty);
        Task<WalkDifficulty?> UpdateAsync(Guid Id, WalkDifficulty walkDifficulty);
        Task<WalkDifficulty?> DeleteAsync(Guid Id);

    }
}
