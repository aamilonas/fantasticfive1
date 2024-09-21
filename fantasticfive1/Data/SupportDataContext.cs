using Microsoft.EntityFrameworkCore;

public class SupportDataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public SupportDataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(Configuration.GetConnectionString("SupportDb"));
    }

    public DbSet<Shelter> Shelters { get; set; }
    public DbSet<Landmark> Landmarks { get; set; }

    public DbSet<Food> Food { get; set; }

    public DbSet<Job> Jobs { get; set; }

    public DbSet<DonationPass> DonationPasses { get; set; }
}

