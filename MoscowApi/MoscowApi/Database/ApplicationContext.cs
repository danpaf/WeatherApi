using MoscowApi.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace MoscowApi.Database;

public sealed class ApplicationContext : DbContext
{
    public DbSet<Weather> Weathers { get; init; }
    public DbSet<User> Users { get; init; }

    private IConfiguration _configuration;

    public ApplicationContext(IConfiguration configuration)
    {
        _configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("default"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Weather>(entity =>
        {
            entity.HasKey(x => x.Uid);
            entity.ToTable("weather");

            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(x => x.Date).HasColumnName("date");
            entity.Property(x => x.TemperatureC).HasColumnName("temperatureC");
            entity.Property(x => x.TemperatureF).HasColumnName("temperatureF");
        });
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Uid);
            entity.ToTable("users");

            entity.Property(x => x.Uid).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(x => x.Username).HasColumnName("username");
            entity.Property(x => x.Username).HasColumnName("password");
        });


        base.OnModelCreating(modelBuilder);
    }
}