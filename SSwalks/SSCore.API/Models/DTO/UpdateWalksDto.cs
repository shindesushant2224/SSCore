namespace SSCore.API.Models.DTO
{
    public class UpdateWalksDto
    {
        public string Name { get; set; }
        public double Lenght { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
    }
}
