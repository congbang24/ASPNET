using Microsoft.EntityFrameworkCore;
using Day6_NguyenCongBang_baitap.Models;

public class Day6_NguyenCongBang_baitapContext : DbContext
{
    public Day6_NguyenCongBang_baitapContext(DbContextOptions<Day6_NguyenCongBang_baitapContext> options) : base(options)
    {
    }

    public DbSet<Genre> Genre { get; set; } = default!;
    public DbSet<Movie> Movie { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Cấu hình mối quan hệ 1-N giữa Genre và Movie
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(m => m.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
