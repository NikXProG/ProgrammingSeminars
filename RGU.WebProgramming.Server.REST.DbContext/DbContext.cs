using Microsoft.EntityFrameworkCore;
using RGU.WebProgramming.Server.REST.Models;

namespace RGU.WebProgramming.Server.REST.DbContext;
public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<ModelAuthors> Authors { get; set; }
    public DbSet<ModelBooks> Books { get; set; }

    
}