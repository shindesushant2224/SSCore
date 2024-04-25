using Microsoft.EntityFrameworkCore;
using SSCore.API.Data;
using SSCore.API.Models.Domain;

namespace SSCore.API.Repositories.RegionRepository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly SSWalksDbContext dbContext;

        public RegionRepository(SSWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Region>> GetRegions()
        {
            return await dbContext.Regions.Include("Walks").ToListAsync();
        }

        public async Task<Region?> GetRegion(Guid Id)
        {
            var region = await dbContext.Regions.FindAsync(Id);
            if (region == null)
            {
                return null;
            }
            return region;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> UpdateAsync(Guid Id, Region region)
        {
            var ExistingRegion = await dbContext.Regions.FindAsync(Id);
            if(ExistingRegion == null)
            {
                return null;
            }
            ExistingRegion.Name = region.Name;
            ExistingRegion.Area = region.Area;
            ExistingRegion.lat = region.lat;
            ExistingRegion.Long = region.Long;
            ExistingRegion.Code = region.Code;
            ExistingRegion.Population = region.Population;

            await dbContext.SaveChangesAsync();
            return ExistingRegion;
        }

        public async Task<Region> DeleteAsync(Guid Id)
        {
            var region = await dbContext.Regions.FindAsync(Id);
            if(region == null)
                return null;

            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();

            return region;
        }
    }
}
