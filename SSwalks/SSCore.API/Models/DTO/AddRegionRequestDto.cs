using System.ComponentModel.DataAnnotations;

namespace SSCore.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Maximum 10 character allowed in Name")]
        [MinLength(3, ErrorMessage = "Minimum character required in Name")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Code must be 3 character")]
        [MaxLength(3, ErrorMessage = "Code must be 3 character")]
        public string Code { get; set; }
        [Required]
        public double Area { get; set; }
        public double lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }
    }
}
