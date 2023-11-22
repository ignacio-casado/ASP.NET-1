using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class CervezasDbContext : DbContext
{
	public CervezasDbContext()
	{
	}

	public CervezasDbContext(DbContextOptions<CervezasDbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Beer> Beers { get; set; } = null!;
	public virtual DbSet<Brand> Brands { get; set; } = null!;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			// Configura tu cadena de conexión aquí
			optionsBuilder.UseSqlServer("Server=DESKTOP-MIB1G7Q; Database=CervezasDb; Trusted_Connection=true;");
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Beer>(entity =>
		{
			entity.ToTable("Beer");

			// Cambia ValueGeneratedNever() a ValueGeneratedOnAdd()
			entity.Property(e => e.BeerId).ValueGeneratedOnAdd();

			entity.Property(e => e.Name).HasMaxLength(255);

			entity.HasOne(d => d.Brand)
				.WithMany(p => p.Beers)
				.HasForeignKey(d => d.BrandId)
				.HasConstraintName("FK__Beer__BrandId__3D5E1FD2");
		});

		modelBuilder.Entity<Brand>(entity =>
		{
			entity.ToTable("Brand");

			// Cambia ValueGeneratedNever() a ValueGeneratedOnAdd()
			entity.Property(e => e.BrandId).ValueGeneratedOnAdd();

			entity.Property(e => e.Name).HasMaxLength(255);
		});
	}
}
