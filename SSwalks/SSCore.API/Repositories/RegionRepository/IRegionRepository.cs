using SSCore.API.Models.Domain;

namespace SSCore.API.Repositories.RegionRepository
{
    public interface IRegionRepository
    {
        public Task<IEnumerable<Region>> GetRegions();
        public Task<Region?> GetRegion(Guid Id);

        public Task<Region> CreateAsync(Region region);
        public Task<Region> UpdateAsync(Guid Id, Region region);
        public Task<Region> DeleteAsync(Guid Id);
    }
}
