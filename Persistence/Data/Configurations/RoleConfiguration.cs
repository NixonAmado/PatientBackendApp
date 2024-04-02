using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class RoleConfiguration:IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.HasKey(p => p.Id).HasName("PRIMARY");
        builder.Property(p => p.Description)
        .IsRequired()
        .HasMaxLength(40);

        builder
        .HasMany(p => p.Users)
        .WithMany(p => p.Roles)
        .UsingEntity<UserRole>(

            j => j
            .HasOne(p => p.UserNavigation)
            .WithMany(p => p.UsersRoles)
            .HasForeignKey(p => p.User_id),
            j => j
            .HasOne(p => p.RoleNavigation)
            .WithMany(p => p.UsersRoles)
            .HasForeignKey(p => p.Role_id),
            j =>
            {
                j.HasKey(t => new {t.Role_id,t.User_id});
            });        
    }

}