using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using HostelStudents.BusinessLogic.Data;
using HostelStudents.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace HostelStudents.BusinessLogic.Entities.Importers;

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

        var hostelList = await context.Hostels.ToListAsync();
        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            var hostel = hostelList.FirstOrDefault(x =>
                true
                && x.NormalizedName.Equals(record.Hostel_NormalizedName)
            );

            // ManyToOneCodePlaceholder

            if (true
            // NullCheckCodePlaceholder
            )
            {
                var student = new Student
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,

                    Age = record.Age,
                    FirstName = record.FirstName,
                    NormalizedFirstName = record.FirstName.ToUpperInvariant(),
                    Hostel = hostel,
                    LastName = record.LastName,
                    NormalizedLastName = record.LastName.ToUpperInvariant(),
                    // NewEntityCodePlaceholder
                };

                var dbStudent = await context.Students.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedFirstName.Equals(student.NormalizedFirstName)
                    && x.NormalizedLastName.Equals(student.NormalizedLastName)
                    // CompositeKeyCodePlaceholder
                );

                if (dbStudent is null)
                {
                    await context.Students.AddAsync(student);
                }
                else
                {
                    dbStudent.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbStudent.UpdateDateTime = DateTime.UtcNow;

                    dbStudent.Age = record.Age;
                    dbStudent.FirstName = record.FirstName;
                    dbStudent.Hostel = hostel;
                    dbStudent.LastName = record.LastName;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
