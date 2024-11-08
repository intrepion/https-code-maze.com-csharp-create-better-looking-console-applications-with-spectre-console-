﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HostelStudents.BusinessLogic.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; } = [];
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public ICollection<ApplicationRole> UpdatedApplicationRoles { get; set; } = [];
    public ICollection<ApplicationRoleClaim> UpdatedApplicationRoleClaims { get; set; } = [];
    public ICollection<ApplicationUser> UpdatedApplicationUsers { get; set; } = [];
    public ICollection<ApplicationUserClaim> UpdatedApplicationUserClaims { get; set; } = [];
    public ICollection<ApplicationUserLogin> UpdatedApplicationUserLogins { get; set; } = [];
    public ICollection<ApplicationUserRole> UpdatedApplicationUserRoles { get; set; } = [];
    public ICollection<ApplicationUserToken> UpdatedApplicationUserTokens { get; set; } = [];

    public ICollection<Hostel> UpdatedHostels { get; set; } = [];
    public ICollection<Student> UpdatedStudents { get; set; } = [];
    public Student? Student { get; set; }
    public Guid? StudentId { get; set; }
    // ActualPropertyPlaceholder
}
