﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HostelStudents.BusinessLogic.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }

    // ActualPropertyPlaceholder
}
