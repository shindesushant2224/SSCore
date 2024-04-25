using Microsoft.EntityFrameworkCore;
using SSCore.API.Models.Domain;

namespace SSCore.API.Data
{
    public class SSWalksDbContext : DbContext
    {
        private readonly DbContextOptions<SSWalksDbContext> dbContext;

        public SSWalksDbContext(DbContextOptions<SSWalksDbContext> dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

        //Seed Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var difficulties = new List<WalkDifficulty>()
            {
                new WalkDifficulty
                {
                    Id = Guid.Parse("d503b6e0-64ff-49a3-9dab-8843378eb74c"),
                    Code = "Easy"
                },
                new WalkDifficulty
                {
                    Id = Guid.Parse("8cdd93fb-b116-41f5-91a3-5fd973a56023"),
                    Code = "Medium"
                },
                new WalkDifficulty
                {
                    Id = Guid.Parse("6638981e-3977-40a1-9dd2-89ee1b466c49"),
                    Code = "Hard"
                }
            };
            modelBuilder.Entity<WalkDifficulty>().HasData(difficulties);
        }
    }
}
