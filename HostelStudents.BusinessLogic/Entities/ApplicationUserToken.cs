using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }

    // ActualPropertyPlaceholder
}
