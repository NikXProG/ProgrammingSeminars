using Microsoft.EntityFrameworkCore;
using RGU.WebProgramming.Server.REST.Models;


namespace RGU.WebProgramming.Server.DbContext;
public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<ModelExample> Authors { get; set; }
    
}