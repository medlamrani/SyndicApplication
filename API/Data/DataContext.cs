using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; } 
    public DbSet<Role> Roles { get; set; }
    
    public DbSet<Residence> Residences { get; set; }
    
    public DbSet<Immeuble> Immeubles { get; set; }
    
    public DbSet<Appartement> Appartements { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Relationships
        modelBuilder.Entity<AppUser>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        // AppUser-Residence: One-to-Many
        modelBuilder.Entity<Residence>()
            .HasOne(r => r.Manager)
            .WithMany() // Assuming managers don't need a direct navigation property for managed residences
            .HasForeignKey(r => r.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Residence-Immeuble: One-to-Many
        modelBuilder.Entity<Immeuble>()
            .HasOne(i => i.Residence)
            .WithMany(r => r.Immeubles)
            .HasForeignKey(i => i.ResidenceId)
            .OnDelete(DeleteBehavior.Restrict);

        // Immeuble-Appartement: One-to-Many
        modelBuilder.Entity<Appartement>()
            .HasOne(a => a.Immeuble)
            .WithMany(i => i.Appartements)
            .HasForeignKey(a => a.ImmeubleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
