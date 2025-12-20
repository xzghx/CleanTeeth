using CleanTeeth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Configurations;

public class PatientConfig : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(c => c.Name)
            .HasMaxLength(50)
            .IsRequired(true);

        builder.ComplexProperty(p => p.Email,
            email =>
            {
                email.Property(e => e.Value)
                .HasMaxLength(254)
                .HasColumnName("Email");
            }

        );
    }
}
