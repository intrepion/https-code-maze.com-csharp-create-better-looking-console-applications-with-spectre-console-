namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class StudentAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public int Age { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public Hostel? Hostel { get; set; }
    public string LastName { get; set; } = string.Empty;
    // DtoPropertyPlaceholder

    public static StudentAdminDto FromStudent(Student? student)
    {
        if (student == null)
        {
            return new StudentAdminDto();
        }

        return new StudentAdminDto
        {
            Id = student.Id,

            Age = student.Age,
            FirstName = student.FirstName,
            Hostel = student.Hostel,
            // EntityToDtoPlaceholder
        };
    }

    public static Student ToStudent(ApplicationUser? applicationUser, StudentAdminDto? studentAdminDto)
    {
        return new Student
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = studentAdminDto?.Id ?? new Guid(),

            Age = studentAdminDto?.Age ?? -1,
            FirstName = studentAdminDto?.FirstName ?? string.Empty,
            Hostel = studentAdminDto?.Hostel,
            // DtoToEntityPropertyPlaceholder
        };
    }
}
