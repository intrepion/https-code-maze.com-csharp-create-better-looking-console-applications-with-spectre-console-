﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using HostelStudents.BusinessLogic.Data;
using HostelStudents.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace HostelStudents.BusinessLogic.Entities.Importers;

public static class ApplicationUserImporter
{
    public static async Task ImportAsync(
        ApplicationDbContext context,
        string userName, string csvPath
    )
    {
        if (!File.Exists(csvPath))
        {
            Console.WriteLine("File not found: " + csvPath);
            return;
        }

        if (context.Users is null)
        {
            Console.WriteLine("Database table not found: context.Users");
            return;
        }

        var normalizedUserName = userName.ToUpperInvariant();
        var applicationUserUpdatedBy = await context.Users.SingleOrDefaultAsync(x => x.NormalizedUserName != null && x.NormalizedUserName.Equals(normalizedUserName));

        if (applicationUserUpdatedBy is null)
        {
            Console.WriteLine("UserName not found: " + userName);
            return;
        }

        using var reader = new StreamReader(csvPath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = x => x.Header.ToUpper(CultureInfo.InvariantCulture),
            Delimiter = "|",
        });

        var records = csv.GetRecords<ApplicationUserRecord>();

        var studentList = await context.Students.ToListAsync();
        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            var student = studentList.FirstOrDefault(x =>
                true
                && x.NormalizedFirstName == record.Student_NormalizedFirstName
                && x.NormalizedLastName == record.Student_NormalizedLastName
            );

            // ManyToOneCodePlaceholder

            if (
                true
            // NullCheckCodePlaceholder
            )
            {
                var applicationUser = new ApplicationUser
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,
                    Email = record.Email,
                    EmailConfirmed = record.EmailConfirmed,
                    NormalizedEmail = record.Email.ToUpper(CultureInfo.InvariantCulture),
                    NormalizedUserName = record.UserName.ToUpper(CultureInfo.InvariantCulture),
                    PhoneNumber = record.PhoneNumber,
                    UserName = record.UserName,

                    Student = student,
                    // NewEntityCodePlaceholder
                };

                var dbApplicationUser = await context.Users.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedUserName != null
                    && x.NormalizedUserName == applicationUser.NormalizedUserName
                    // CompositeKeyCodePlaceholder
                );

                if (dbApplicationUser is null)
                {
                    await context.Users.AddAsync(applicationUser);
                }
                else
                {
                    dbApplicationUser.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbApplicationUser.UpdateDateTime = DateTime.UtcNow;
                    dbApplicationUser.Email = record.Email;
                    dbApplicationUser.EmailConfirmed = record.EmailConfirmed;
                    dbApplicationUser.NormalizedEmail = record.Email.ToUpper(CultureInfo.InvariantCulture);
                    dbApplicationUser.NormalizedUserName = record.UserName.ToUpper(CultureInfo.InvariantCulture);
                    dbApplicationUser.PhoneNumber = record.PhoneNumber;

                    dbApplicationUser.Student = student;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
