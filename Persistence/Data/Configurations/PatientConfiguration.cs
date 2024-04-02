
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

public class PatientConfiguration:IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");
        builder.ToTable("Patient");

        builder.Property(e => e.Name)
        .HasMaxLength(100)
        .IsRequired();
        
        builder.Property(e => e.Address)
        .HasMaxLength(70)
        .IsRequired();

        builder.Property(e => e.DNI)
        .HasMaxLength(70)
        .IsRequired();

        builder.Property(e => e.Email)
        .HasMaxLength(70)
        .IsRequired();

        builder.Property(e => e.PostalCode)
        .HasMaxLength(70)
        .IsRequired();

        builder.Property(e => e.Gender)
        .HasMaxLength(70)
        .IsRequired();

        builder.Property(e => e.Phone_number)
        .IsRequired();

        builder.Property(e => e.Birth_date)
        .IsRequired()
        .HasColumnType("Date");


    }
}  
  
 