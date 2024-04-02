using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;
public class RefreshTokenConfiguration:IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
     builder.ToTable("RefreshToken");

        builder.HasKey(p => p.Id).HasName("PRIMARY");
        builder.HasOne(p => p.UserNavigation)
        .WithMany(p => p.RefreshTokens)
        .HasForeignKey(p => p.User_id);

        builder.Property(p => p.Token)
        .IsRequired()
        .HasMaxLength(300);

        builder.Property(p => p.Created)
        .IsRequired()
        .HasColumnType("DateTime");

        builder.Property(p => p.Expires)
        .IsRequired()
        .HasColumnType("DateTime");

        builder.Property(p => p.Revoked)
        .HasColumnType("DateTime");
    }

}