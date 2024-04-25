using AutoMapper;
using SSCore.API.Models.Domain;
using SSCore.API.Models.DTO;

namespace SSCore.API.Mappings
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region,AddRegionRequestDto>().ReverseMap();
            CreateMap<Region,UpdateRegionRequestDto>().ReverseMap();
        }
    }
}
