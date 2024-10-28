using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class StudentAdminEditViewModel
{
    public Guid Id { get; set; }

    public int Age { get; set; }
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

            // ModelToDtoPlaceholder
        };
    }
}
