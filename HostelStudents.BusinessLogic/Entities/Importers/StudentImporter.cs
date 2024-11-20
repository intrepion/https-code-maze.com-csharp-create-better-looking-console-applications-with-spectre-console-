using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Importers;

public static class StudentImporter
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

        if (context.Students is null)
        {
            Console.WriteLine("Database table not found: context.Students");
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

        var records = csv.GetRecords<StudentRecord>();

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            // ManyToOneCodePlaceholder

            if (true
                // NullCheckCodePlaceholder
            )
            {
                var student = new Student
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,

                    Age = record.Age,
                    // NewEntityCodePlaceholder
                };

                var dbStudent = await context.Students.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedFirstName == student.NormalizedFirstName
                    && x.NormalizedLastName == student.NormalizedLastName
                    // CompositeKeyCodePlaceholder
                );

                if (dbStudent is null)
                {
                    await context.Students.AddAsync(student);
                }
                else
                {
                    dbStudent.ApplicationUserUpdatedBy = applicationUserUpdatedBy;

                    dbStudent.Age = record.Age;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
