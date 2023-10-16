using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNo_Face.Model;

namespace BNo_Face.DataAccess.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Bill> Bills { get; set; }
		public DbSet<List_Product> List_Products { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Use HasKey to define the primary key for the List_Product entity
			modelBuilder.Entity<List_Product>()
				.HasKey(lp => new { lp.ProductID, lp.BillID });
			modelBuilder.Entity<List_Product>()
			.HasOne(lp => lp.Product)
			.WithMany()
			.HasForeignKey(lp => lp.ProductID)
			.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<List_Product>()
				.HasOne(lp => lp.Bill)
				.WithMany()
				.HasForeignKey(lp => lp.BillID)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
