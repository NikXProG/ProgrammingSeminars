using Microsoft.EntityFrameworkCore;

namespace RGU.WebProgramming.Server.Grpc.DbContext;
public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    // public DbSet<ModelAuthors> Authors { get; set; }
    //
    // public DbSet<ModelBooks> Books { get; set; }
    //
    // public DbSet<ModelReaders> Readers { get; set; }
    //
    // public DbSet<ModelPublishers> Publishers { get; set; }
    
}