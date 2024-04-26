using AutoMapper;
using SSCore.API.Models.Domain;
using SSCore.API.Models.DTO;

namespace SSCore.API.Mappings
{
    public class WalkDifficultyProfile:Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<WalkDifficulty,WalkDifficultyDto>().ReverseMap();
            CreateMap<WalkDifficulty,AddWalkDifficultyDto>().ReverseMap();
            CreateMap<WalkDifficulty,UpdateWalkDifficultyDto>().ReverseMap();
        }
    }
}
