using AutoMapperMVC.Models.ORM;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperMVC.Models;

public class AutoMapperDbContext : DbContext
{
	public AutoMapperDbContext(DbContextOptions<AutoMapperDbContext> options) : base(options)
	{

	}

	public DbSet<Customer> Customers { get; set; }
	public DbSet<Address> Addresses { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Product> Products { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(9, 2);
		modelBuilder.Entity<Product>().Property(p => p.UnitsInStock).HasAnnotation("MinValue",0);
		modelBuilder.Entity<Product>().Property(p => p.ProductName).IsRequired();
	}
}
