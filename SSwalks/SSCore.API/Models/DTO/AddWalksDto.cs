using System.ComponentModel.DataAnnotations;

namespace SSCore.API.Models.DTO
{
    public class AddWalksDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Lenght { get; set; }
        [Required]
        public Guid RegionId { get; set; }
        [Required]
        public Guid WalkDifficultyId { get; set; }
    }
}
