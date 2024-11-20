using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using HostelStudents.BusinessLogic.Data;
using HostelStudents.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace HostelStudents.BusinessLogic.Entities.Importers;

public static class HostelImporter
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

        if (context.Hostels is null)
        {
            Console.WriteLine("Database table not found: context.Hostels");
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

        var records = csv.GetRecords<HostelRecord>();

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            // ManyToOneCodePlaceholder

            if (true
            // NullCheckCodePlaceholder
            )
            {
                var hostel = new Hostel
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,

                    Name = record.Name,
                    NormalizedName = record.Name.ToUpper(CultureInfo.InvariantCulture),
                    // NewEntityCodePlaceholder
                };

                var dbHostel = await context.Hostels.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedName == hostel.NormalizedName
                    // CompositeKeyCodePlaceholder
                );

                if (dbHostel is null)
                {
                    await context.Hostels.AddAsync(hostel);
                }
                else
                {
                    dbHostel.ApplicationUserUpdatedBy = applicationUserUpdatedBy;

                    dbHostel.Name = record.Name;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
