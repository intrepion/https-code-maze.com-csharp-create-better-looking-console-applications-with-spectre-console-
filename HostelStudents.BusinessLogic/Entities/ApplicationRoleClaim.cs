using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HostelStudents.BusinessLogic.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }

    // ActualPropertyPlaceholder
}
