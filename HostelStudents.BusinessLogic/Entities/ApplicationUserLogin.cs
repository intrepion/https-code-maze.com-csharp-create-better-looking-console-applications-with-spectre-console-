using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HostelStudents.BusinessLogic.Entities;

public class ApplicationUserLogin : IdentityUserLogin<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }

    // ActualPropertyPlaceholder
}
