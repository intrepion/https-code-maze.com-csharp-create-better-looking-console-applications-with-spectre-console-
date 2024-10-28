using Microsoft.AspNetCore.Identity;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
