using HostelStudents.BusinessLogic.Entities;
using HostelStudents.BusinessLogic.Entities.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HostelStudents.BusinessLogic.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>(options)
{
    public DbSet<Hostel> Hostels { get; set; }
    public DbSet<Student> Students { get; set; }
    // DbSetCodePlaceholder

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        new ApplicationRoleClaimEtc().Configure(builder.Entity<ApplicationRoleClaim>());
        new ApplicationRoleEtc().Configure(builder.Entity<ApplicationRole>());
        new ApplicationUserEtc().Configure(builder.Entity<ApplicationUser>());
        new ApplicationUserClaimEtc().Configure(builder.Entity<ApplicationUserClaim>());
        new ApplicationUserLoginEtc().Configure(builder.Entity<ApplicationUserLogin>());
        new ApplicationUserRoleEtc().Configure(builder.Entity<ApplicationUserRole>());
        new ApplicationUserTokenEtc().Configure(builder.Entity<ApplicationUserToken>());

        new HostelEtc().Configure(builder.Entity<Hostel>());
        new StudentEtc().Configure(builder.Entity<Student>());
        // EntityTypeCfgCodePlaceholder
    }
}
