using HostelStudents.BusinessLogic.Entities.Dtos.Admin;

namespace HostelStudents.BusinessLogic.Entities.ViewModels.Admin;

public class HostelAdminEditViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder

    public static HostelAdminEditViewModel FromHostelAdminDto(HostelAdminDto hostelAdminDto)
    {
        if (hostelAdminDto == null)
        {
            return new HostelAdminEditViewModel();
        }

        return new HostelAdminEditViewModel
        {
            Id = hostelAdminDto.Id,

            Name = hostelAdminDto?.Name ?? string.Empty,
            // DtoToModelPlaceholder
        };
    }

    public static HostelAdminDto ToHostelAdminDto(HostelAdminEditViewModel hostelAdminEditViewModel)
    {
        if (hostelAdminEditViewModel == null)
        {
            return new HostelAdminDto();
        }

        return new HostelAdminDto
        {
            Id = hostelAdminEditViewModel.Id,

            Name = hostelAdminEditViewModel.Name,
            // ModelToDtoPlaceholder
        };
    }
}
