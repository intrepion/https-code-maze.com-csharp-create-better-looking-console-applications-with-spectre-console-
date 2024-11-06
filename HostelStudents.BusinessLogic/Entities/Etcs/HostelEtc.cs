using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostelStudents.BusinessLogic.Entities.Configuration;

public class HostelEtc : IEntityTypeConfiguration<Hostel>
{
    public void Configure(EntityTypeBuilder<Hostel> builder)
    {
        builder.ToTable("Hostels", x => x.IsTemporal());

        // EntityConfigurationCodePlaceholder

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedHostels)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
