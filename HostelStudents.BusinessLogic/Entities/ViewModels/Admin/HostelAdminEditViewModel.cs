using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class EntityNamePlaceholderAdminEditViewModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static EntityNamePlaceholderAdminEditViewModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholderAdminDto)
    {
        if (EntityLowercaseNamePlaceholderAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditViewModel();
        }

        return new EntityNamePlaceholderAdminEditViewModel
        {
            Id = EntityLowercaseNamePlaceholderAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditViewModel EntityLowercaseNamePlaceholderAdminEditViewModel)
    {
        if (EntityLowercaseNamePlaceholderAdminEditViewModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = EntityLowercaseNamePlaceholderAdminEditViewModel.Id,

            // ModelToDtoPlaceholder
        };
    }
}
