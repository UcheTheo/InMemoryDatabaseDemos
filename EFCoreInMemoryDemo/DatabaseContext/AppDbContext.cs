using EFCoreInMemoryDemo.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInMemoryDemo.DatabaseContext;

public class AppDbContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");
	}

	public DbSet<ProductDataModel> Products { get; set; }
}
