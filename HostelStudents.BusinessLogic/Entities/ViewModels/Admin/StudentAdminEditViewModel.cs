using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class StudentAdminEditViewModel
{
    public Guid Id { get; set; }

    public int Age { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public Hostel? Hostel { get; set; }
    public string LastName { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder

    public static StudentAdminEditViewModel FromStudentAdminDto(StudentAdminDto studentAdminDto)
    {
        if (studentAdminDto == null)
        {
            return new StudentAdminEditViewModel();
        }

        return new StudentAdminEditViewModel
        {
            Id = studentAdminDto.Id,

            Age = studentAdminDto?.Age ?? -1,
            FirstName = studentAdminDto?.FirstName ?? string.Empty,
            Hostel = studentAdminDto?.Hostel,
            LastName = studentAdminDto?.LastName ?? string.Empty,
            // DtoToModelPlaceholder
        };
    }

    public static StudentAdminDto ToStudentAdminDto(StudentAdminEditViewModel studentAdminEditViewModel)
    {
        if (studentAdminEditViewModel == null)
        {
            return new StudentAdminDto();
        }

        return new StudentAdminDto
        {
            Id = studentAdminEditViewModel.Id,

            Age = studentAdminEditViewModel.Age,
            FirstName = studentAdminEditViewModel.FirstName,
            Hostel = studentAdminEditViewModel.Hostel,
            LastName = studentAdminEditViewModel.LastName,
            // ModelToDtoPlaceholder
        };
    }
}
