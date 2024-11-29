using System.ComponentModel.DataAnnotations;

namespace HostelStudents.BusinessLogic.Entities;

public class Hostel
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime UpdateDateTime { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string NormalizedName { get; set; } = string.Empty;
    public ICollection<Student> Students { get; set; } = [];
    // ActualPropertyPlaceholder
}
