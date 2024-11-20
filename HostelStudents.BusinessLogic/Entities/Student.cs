using System.ComponentModel.DataAnnotations;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class Student
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    [Required]
    public int Age { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string NormalizedFirstName { get; set; } = string.Empty;
    public Hostel? Hostel { get; set; }
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public string NormalizedLastName { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
