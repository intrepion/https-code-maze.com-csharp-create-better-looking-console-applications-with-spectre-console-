using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostelStudents.BusinessLogic.Entities.Configuration;

public class ApplicationUserEtc : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedApplicationUsers)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Student)
            .WithOne(x => x.ApplicationUser)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder
    }
}
