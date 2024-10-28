namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class StudentAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public int Age { get; set; }
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
            // EntityToDtoPlaceholder
        };
    }

    public static Student ToStudent(ApplicationUser? applicationUser, StudentAdminDto? studentAdminDto)
    {
        return new Student
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = studentAdminDto?.Id ?? new Guid(),

            // DtoToEntityPropertyPlaceholder
        };
    }
}
