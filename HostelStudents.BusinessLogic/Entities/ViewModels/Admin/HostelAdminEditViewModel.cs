using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class HostelAdminEditViewModel
{
    public Guid Id { get; set; }

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

            // ModelToDtoPlaceholder
        };
    }
}
