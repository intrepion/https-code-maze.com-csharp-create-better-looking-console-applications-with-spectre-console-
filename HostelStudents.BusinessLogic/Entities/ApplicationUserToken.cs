using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HostelStudents.BusinessLogic.Entities;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }

    // ActualPropertyPlaceholder
}
