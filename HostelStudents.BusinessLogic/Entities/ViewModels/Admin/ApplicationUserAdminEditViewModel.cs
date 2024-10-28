using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class ApplicationUserAdminEditViewModel
{
    public List<ApplicationRole> ApplicationRoles { get; set; } = [];
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public static ApplicationUserAdminEditViewModel FromApplicationUserAdminDto(ApplicationUserAdminDto applicationUserAdminDto)
    {
        if (applicationUserAdminDto == null)
        {
            return new ApplicationUserAdminEditViewModel();
        }

        var applicationUserAdminEditViewModel = new ApplicationUserAdminEditViewModel
        {
            ApplicationRoles = applicationUserAdminDto.ApplicationRoles,
            Email = applicationUserAdminDto.Email,
            Id = applicationUserAdminDto.Id,
            PhoneNumber = applicationUserAdminDto.PhoneNumber,
            UserName = applicationUserAdminDto.UserName,
        };

        return applicationUserAdminEditViewModel;
    }

    public static ApplicationUserAdminDto ToApplicationUserAdminDto(ApplicationUserAdminEditViewModel? applicationUserAdminEditViewModel)
    {
        if (applicationUserAdminEditViewModel == null)
        {
            return new ApplicationUserAdminDto();
        }

        var applicationUserAdminDto = new ApplicationUserAdminDto
        {
            ApplicationRoles = applicationUserAdminEditViewModel.ApplicationRoles,
            Email = applicationUserAdminEditViewModel.Email,
            Id = applicationUserAdminEditViewModel.Id,
            PhoneNumber = applicationUserAdminEditViewModel.PhoneNumber,
            UserName = applicationUserAdminEditViewModel.UserName,
        };

        return applicationUserAdminDto;
    }
}
