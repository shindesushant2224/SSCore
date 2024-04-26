using System.ComponentModel.DataAnnotations;

namespace SSCore.API.Models.DTO
{
    public class UpdateWalkDifficultyDto
    {
        [Required]
        public string Code { get; set; }
    }
}
