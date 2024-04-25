using AutoMapper;
using SSCore.API.Models.Domain;
using SSCore.API.Models.DTO;

namespace SSCore.API.Mappings
{
    public class WalksProfile:Profile
    {
        public WalksProfile()
        {
            CreateMap<Walk,WalkDto>().ReverseMap();
            CreateMap<WalkDifficulty, WalkDifficultyDto>().ReverseMap();
            CreateMap<Walk,AddWalksDto>().ReverseMap();
            CreateMap<Walk,UpdateWalksDto>().ReverseMap();

        }
    }
}
