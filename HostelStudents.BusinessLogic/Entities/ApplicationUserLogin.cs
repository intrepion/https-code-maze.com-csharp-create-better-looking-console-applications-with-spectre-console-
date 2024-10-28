using Microsoft.AspNetCore.Identity;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class ApplicationUserLogin : IdentityUserLogin<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
