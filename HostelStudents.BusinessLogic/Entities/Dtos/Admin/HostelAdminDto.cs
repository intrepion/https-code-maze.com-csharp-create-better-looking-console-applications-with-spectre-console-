namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class EntityNamePlaceholderAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder

    public static EntityNamePlaceholderAdminDto FromEntityNamePlaceholder(EntityNamePlaceholder? hostel)
    {
        if (hostel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = hostel.Id,

            // EntityToDtoPlaceholder
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser? applicationUser, EntityNamePlaceholderAdminDto? hostelAdminDto)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = hostelAdminDto?.Id ?? new Guid(),

            // DtoToEntityPropertyPlaceholder
        };
    }
}
