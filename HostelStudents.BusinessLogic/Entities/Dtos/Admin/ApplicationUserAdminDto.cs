namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class ApplicationUserAdminDto
{
    public List<ApplicationRole> ApplicationRoles { get; set; } = [];
    public string ApplicationUserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public static ApplicationUserAdminDto FromApplicationUser(ApplicationUser applicationUser)
    {
        return new ApplicationUserAdminDto
        {
            ApplicationRoles = applicationUser.ApplicationUserRoles.Select(x => x.ApplicationRole ?? new ApplicationRole()).ToList(),
            Email = applicationUser.Email ?? string.Empty,
            Id = applicationUser.Id,
            PhoneNumber = applicationUser.PhoneNumber ?? string.Empty,
            UserName = applicationUser.UserName ?? string.Empty,
        };
    }

    public static ApplicationUser ToApplicationUser(ApplicationUser applicationUser, ApplicationUserAdminDto applicationUserAdminDto)
    {
        return new ApplicationUser
        {
            ApplicationUserUpdatedBy = applicationUser,
            Email = applicationUserAdminDto.Email,
            Id = applicationUserAdminDto.Id,
            PhoneNumber = applicationUserAdminDto.PhoneNumber,
            UserName = applicationUserAdminDto.UserName,
        };
    }
}
