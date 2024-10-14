using Microsoft.EntityFrameworkCore;
using ScapeLand.Entity;

namespace ScapeLand.Data;

public class AppDbContext(DbContextOptions<AppDbContext> opts) : DbContext(opts)
{

}
