namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class Student
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public int Age { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string NormalizedFirstName { get; set; } = string.Empty;
    public Hostel? Hostel { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string NormalizedLastName { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
