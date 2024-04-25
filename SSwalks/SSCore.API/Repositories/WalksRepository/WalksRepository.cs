using Microsoft.EntityFrameworkCore;
using SSCore.API.Data;
using SSCore.API.Models.Domain;

namespace SSCore.API.Repositories.WalksRepository
{
    public class WalksRepository : IWalksRepository
    {
        private readonly SSWalksDbContext dbContext;

        public WalksRepository(SSWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Walk>> GetWalksAsync()
        {
            return await dbContext.Walks
                .Include(x => x.region)
                .Include(x => x.walkDiffuculty)
                .ToListAsync();
        }
        public async Task<Walk?> GetWalkAsync(Guid Id)
        {
            var walk = await dbContext.Walks.Include("region").Include("walkDiffuculty").FirstOrDefaultAsync(w => w.Id == Id);
            return walk;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();

            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> UpdateAsync(Guid Id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(w => w.Id == Id);
            if (existingWalk == null)
            {
                return null;
            }
            existingWalk.Lenght = walk.Lenght;
            existingWalk.Name = walk.Name;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
            
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<Walk?> DeleteAsync(Guid Id)
        {
            var walk = await dbContext.Walks.FirstOrDefaultAsync(w => w.Id == Id);
            if (walk == null)
                return null;
            dbContext.Walks.Remove(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }
    }
}
