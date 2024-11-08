using System.ComponentModel.DataAnnotations;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class Hostel
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    // ActualPropertyPlaceholder
}
