namespace SSCore.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Lenght { get; set; }

        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        //Navigation Properties
        public Region region { get; set; }
        public WalkDifficulty walkDiffuculty { get; set; }
    }
}
