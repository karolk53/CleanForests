using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : IdentityDbContext<AppUser, AppRole, int, 
    IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, 
    IdentityRoleClaim<int>, IdentityUserToken<int>>
{

    public DbSet<Club> Clubs { get; set; }
    public DbSet<Address> Addresses { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Address>()
            .HasOne(c => c.Club)
            .WithOne(a => a.Address)
            .HasForeignKey<Club>(fk => fk.AddressId);
        
        builder.Entity<Club>()
            .HasOne(a => a.Address)
            .WithOne(c => c.Club)
            .HasForeignKey<Address>(fk => fk.ClubId);
    }
}