using Microsoft.EntityFrameworkCore;
using StorageApi.API.Models;

namespace StorageApi.API.Data;
public class StorageDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=MyDatabase.db");
    }
    public StorageDbContext(DbContextOptions<StorageDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
