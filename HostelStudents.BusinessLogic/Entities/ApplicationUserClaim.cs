using Microsoft.AspNetCore.Identity;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class ApplicationUserClaim : IdentityUserClaim<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
