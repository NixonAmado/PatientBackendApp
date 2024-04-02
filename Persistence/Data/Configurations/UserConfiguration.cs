using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class UserConfiguration:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(p => p.Id).HasName("PRIMARY");
        builder.Property(p => p.User_name)
        .IsRequired()
        .HasColumnName("user_name")
        .HasMaxLength(40);

        builder.Property(p => p.User_email)
        .IsRequired()
        .HasColumnName("email")
        .HasMaxLength(40);

        builder.Property(p => p.User_password)
        .IsRequired()
        .HasColumnName("password")
        .HasMaxLength(255);


    }

}