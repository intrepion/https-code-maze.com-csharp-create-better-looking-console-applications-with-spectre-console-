using Microsoft.AspNetCore.Identity;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
