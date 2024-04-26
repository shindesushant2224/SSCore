using System.ComponentModel.DataAnnotations;

namespace SSCore.API.Models.DTO
{
    public class AddWalkDifficultyDto
    {
        [Required]
        public string Code { get; set; }
    }
}
