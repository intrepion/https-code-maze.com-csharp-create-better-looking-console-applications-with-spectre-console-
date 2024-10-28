using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Configuration;

public class EntityNamePlaceholderEntityTypeConfiguration : IEntityTypeConfiguration<EntityNamePlaceholder>
{
    public void Configure(EntityTypeBuilder<EntityNamePlaceholder> builder)
    {
        builder.ToTable("TableNamePlaceholder", x => x.IsTemporal());

        // EntityConfigurationCodePlaceholder

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedTableNamePlaceholder)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
