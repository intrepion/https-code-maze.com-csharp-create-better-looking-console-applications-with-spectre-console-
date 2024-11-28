using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class ApplicationRole : IdentityRole<Guid>
{
    public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; } = [];
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }

    // ActualPropertyPlaceholder
}
