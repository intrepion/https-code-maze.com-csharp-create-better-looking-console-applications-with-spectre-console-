namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class HostelAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    // DtoPropertyPlaceholder

    public static HostelAdminDto FromHostel(Hostel? hostel)
    {
        if (hostel == null)
        {
            return new HostelAdminDto();
        }

        return new HostelAdminDto
        {
            Id = hostel.Id,

            // EntityToDtoPlaceholder
        };
    }

    public static Hostel ToHostel(ApplicationUser? applicationUser, HostelAdminDto? hostelAdminDto)
    {
        return new Hostel
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = hostelAdminDto?.Id ?? new Guid(),

            // DtoToEntityPropertyPlaceholder
        };
    }
}
