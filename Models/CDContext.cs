#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace ChefsNDishes.Models;

public class CDContext : DbContext
{
  public CDContext(DbContextOptions options) : base(options) { }

  public DbSet<Chef> Chefs { get; set; }
  public DbSet<Dish> Dishes { get; set; }
}