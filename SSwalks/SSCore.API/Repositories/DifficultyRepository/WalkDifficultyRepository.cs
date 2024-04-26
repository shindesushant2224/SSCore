using Microsoft.EntityFrameworkCore;
using SSCore.API.Data;
using SSCore.API.Models.Domain;

namespace SSCore.API.Repositories.DifficultyRepository
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly SSWalksDbContext dbContext;

        public WalkDifficultyRepository(SSWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await dbContext.WalkDifficulty.ToListAsync();
        }
        public async Task<WalkDifficulty?> GetAsync(Guid id)
        {
            var walkDifficulty = await dbContext.WalkDifficulty.FirstOrDefaultAsync(d => d.Id == id);
            if(walkDifficulty == null)
            {
                return null;
            }
            return walkDifficulty;
        }        
        
        public async Task<WalkDifficulty> CreateAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await dbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await dbContext.SaveChangesAsync();
            return walkDifficulty;

        }
        public async Task<WalkDifficulty?> UpdateAsync(Guid Id, WalkDifficulty walkDifficulty)
        {
            var existingDifficulty = await dbContext.WalkDifficulty.FirstOrDefaultAsync(d => d.Id == Id);
            if (existingDifficulty == null)
            {
                return null;
            }
            existingDifficulty.Code = walkDifficulty.Code;
            await dbContext.SaveChangesAsync();
            return existingDifficulty;

        }
        public async Task<WalkDifficulty?> DeleteAsync(Guid Id)
        {
            var walkDifficulty = await dbContext.WalkDifficulty.FirstOrDefaultAsync(d => d.Id == Id);
            if (walkDifficulty == null)
            {
                return null;
            }
            dbContext.WalkDifficulty.Remove(walkDifficulty);
            await dbContext.SaveChangesAsync();
            return walkDifficulty;
        }
        
    }
}
