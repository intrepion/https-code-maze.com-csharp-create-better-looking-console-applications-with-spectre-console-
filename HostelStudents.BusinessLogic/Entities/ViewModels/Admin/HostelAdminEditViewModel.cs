using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class EntityNamePlaceholderAdminEditViewModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static EntityNamePlaceholderAdminEditViewModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto hostelAdminDto)
    {
        if (hostelAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditViewModel();
        }

        return new EntityNamePlaceholderAdminEditViewModel
        {
            Id = hostelAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditViewModel hostelAdminEditViewModel)
    {
        if (hostelAdminEditViewModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = hostelAdminEditViewModel.Id,

            // ModelToDtoPlaceholder
        };
    }
}
