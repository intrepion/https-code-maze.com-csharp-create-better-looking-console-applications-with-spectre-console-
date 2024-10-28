using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class EntityNamePlaceholderAdminEditViewModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static EntityNamePlaceholderAdminEditViewModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto studentAdminDto)
    {
        if (studentAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditViewModel();
        }

        return new EntityNamePlaceholderAdminEditViewModel
        {
            Id = studentAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditViewModel studentAdminEditViewModel)
    {
        if (studentAdminEditViewModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = studentAdminEditViewModel.Id,

            // ModelToDtoPlaceholder
        };
    }
}
