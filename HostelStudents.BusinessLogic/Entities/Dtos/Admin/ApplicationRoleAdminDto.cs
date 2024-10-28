namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class ApplicationRoleAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public static ApplicationRoleAdminDto FromApplicationRole(ApplicationRole? applicationRole)
    {
        if (applicationRole == null)
        {
            return new ApplicationRoleAdminDto();
        }

        return new ApplicationRoleAdminDto
        {
            Id = applicationRole.Id,
            Name = applicationRole.Name ?? string.Empty,
        };
    }

    public static ApplicationRole ToApplicationRole(ApplicationUser applicationUser, ApplicationRoleAdminDto applicationRoleAdminDto)
    {
        return new ApplicationRole
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = applicationRoleAdminDto.Id,
            Name = applicationRoleAdminDto.Name,
            NormalizedName = applicationRoleAdminDto.Name?.ToUpperInvariant()
        };
    }
}
