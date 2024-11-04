using System.ComponentModel.DataAnnotations;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class Student
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    [Required]
    public int Age { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
    // ActualPropertyPlaceholder
}
