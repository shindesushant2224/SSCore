namespace SSCore.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Area { get; set; }
        public double lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }
    }
}
