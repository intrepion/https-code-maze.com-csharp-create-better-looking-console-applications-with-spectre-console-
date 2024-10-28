﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Configuration;

public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students", x => x.IsTemporal());

        builder.HasOne(x => x.ApplicationUser)
            .WithOne(x => x.null)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedStudents)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
