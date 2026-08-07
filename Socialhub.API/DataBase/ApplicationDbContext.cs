using Microsoft.EntityFrameworkCore;
using Socialhub.API.Entities;
namespace Socialhub.API.DataBase;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
    {}
    public DbSet<User> Users => Set<User>();
}


