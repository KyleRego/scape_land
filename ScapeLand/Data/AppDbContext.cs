using Microsoft.EntityFrameworkCore;
using ScapeLand.Entity;

namespace ScapeLand.Data;

public class AppDbContext(DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    public DbSet<OptionNtt> Options { get; set; }
    public DbSet<PromptNtt> Prompts { get; set; }
    public DbSet<OptionResultNtt> Results { get; set; }   
}
