using Azure.KeyVault;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace TechMeet_BE.Domain;

public partial class TechMeetDbContext : DbContext
{
    private readonly string _connectionString = ConnectionHelper.GetConnectionStringAsync().GetAwaiter().GetResult();
    public TechMeetDbContext()
    {
    }

    public TechMeetDbContext(DbContextOptions<TechMeetDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Events_pkey");

            entity.Property(e => e.Description).HasColumnType("character varying");
            entity.Property(e => e.Title).HasColumnType("character varying");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
