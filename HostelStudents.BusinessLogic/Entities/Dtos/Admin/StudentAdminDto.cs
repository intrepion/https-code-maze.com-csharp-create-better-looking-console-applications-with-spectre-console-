namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class EntityNamePlaceholderAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder

    public static EntityNamePlaceholderAdminDto FromEntityNamePlaceholder(EntityNamePlaceholder? student)
    {
        if (student == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = student.Id,

            // EntityToDtoPlaceholder
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser? applicationUser, EntityNamePlaceholderAdminDto? studentAdminDto)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = studentAdminDto?.Id ?? new Guid(),

            // DtoToEntityPropertyPlaceholder
        };
    }
}
