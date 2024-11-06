// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using HostelStudents.BusinessLogic.Entities;
using Spectre.Console;
using Spectre.Console.Json;

Console.WriteLine("Hello, World!");

List<Hostel> _hostels = [
    new Hostel { Name = "Lincoln" },
    new Hostel { Name = "Louisa" },
    new Hostel { Name = "Laurent" },
    new Hostel { Name = "George" },
    new Hostel { Name = "Kennedy" },
];

List<Student> _students = [
    new Student { Id = Guid.NewGuid(), FirstName = "Julie", LastName = "Matthew", Age = 19, Hostel = _hostels[0] },
    new Student { Id = Guid.NewGuid(), FirstName = "Michael", LastName = "Taylor", Age = 23, Hostel = _hostels[3] },
    new Student { Id = Guid.NewGuid(), FirstName = "Joe", LastName = "Hardy", Age = 27, Hostel = _hostels[2] },
    new Student { Id = Guid.NewGuid(), FirstName = "Sabrina", LastName = "Azulon", Age = 18, Hostel = _hostels[3] },
    new Student { Id = Guid.NewGuid(), FirstName = "Hunter", LastName = "Cyril", Age = 19, Hostel = _hostels[4] },
];

var agePrompt = new TextPrompt<int>("[green]How old are you[/]?")
    .PromptStyle("green")
    .ValidationErrorMessage("[red]That's not a valid age[/]")
    .Validate(age =>
    {
        return age switch
        {
            <= 10 => ValidationResult.Error("[red]You must be above 10 years[/]"),
            >= 123 => ValidationResult.Error("[red]You must be younger than that[/]"),
            _ => ValidationResult.Success(),
        };
    });

var selectionPrompt = new SelectionPrompt<string>()
    .Title("Choose a hostel").AddChoices(_hostels.Select(x => x.Name));

var selectedFirstName = AnsiConsole.Ask<string>("[green]What's your First Name[/]?");
var selectedLastName = AnsiConsole.Ask<string>("[green]What's your Last Name[/]?");
var selectedAge = AnsiConsole.Prompt(agePrompt);
var selectedHostel = AnsiConsole.Prompt(selectionPrompt);

var selectedStudent = new Student
{
    FirstName = selectedFirstName,
    LastName = selectedLastName,
    Age = selectedAge,
    Hostel = _hostels.Single(x => x.Name.Equals(selectedHostel, StringComparison.InvariantCultureIgnoreCase)),
};

AnsiConsole.MarkupLine($"Alright [yellow]{selectedStudent.Age}-year-old {selectedStudent.FirstName} {selectedStudent.LastName}[/], welcome to {selectedStudent.Hostel.Name}!");

_students.Add(selectedStudent);

AnsiConsole.Markup($"[bold blue]Hello[/] [italic green]{_students[1].FirstName}[/]!");
AnsiConsole.Write(new Markup($"[underline #800080]{_students[2].FirstName}[/]"));
AnsiConsole.MarkupLine($"[rgb(128,0,0)]{_students[3].FirstName}[/]");

AnsiConsole.MarkupLine($"[red on yellow] Hello, {_students[4].LastName}![/]");

AnsiConsole.Markup($"[[{_students[3].FirstName}]]");
AnsiConsole.MarkupLine($"[blue][[{_students[3].Hostel}]][/]");
AnsiConsole.MarkupLine($"[{_students[3].Age}]".EscapeMarkup());

JsonSerializerOptions _writeOptions = new()
{
    WriteIndented = true
};

var students = JsonSerializer.Serialize(_students, _writeOptions);

var json = new JsonText(students);
var panel = new Panel(json)
        .Header("Students")
        .HeaderAlignment(Justify.Center)
        .SquareBorder()
        .Collapse()
        .BorderColor(Color.LightSkyBlue1);
AnsiConsole.Write(panel);

var calendar = new Calendar(2023, 11)
    .AddCalendarEvent(2023, 11, 19)
    .HighlightStyle(Style.Parse("magenta bold"))
    .HeaderStyle(Style.Parse("purple"));
AnsiConsole.Write(calendar);

var table = new Table
{
    Title = new TableTitle("STUDENTS", "bold green")
};

table.AddColumns("[yellow]Id[/]", $"[{Color.Olive}]FirstName[/]", "[Fuchsia]Age[/]");

foreach (var student in _students)
{
    table.AddRow(student.Id.ToString(), $"[red]{student.FirstName}[/]", $"[cyan]{student.Age}[/]");
}

AnsiConsole.Write(table);

try
{
    File.OpenRead("nofile.txt");
}
catch (FileNotFoundException ex)
{
    AnsiConsole.WriteException(ex,
    ExceptionFormats.ShortenPaths |
    ExceptionFormats.ShortenMethods);
}

var barChart = new BarChart()
    .Width(60)
    .Label("[orange1 bold underline]Number of Students per Hostel[/]")
    .CenterLabel();

var colors = new List<Color> { Color.Red, Color.Fuchsia, Color.Blue, Color.Yellow, Color.Magenta1 };

for (int i = 0; i < _hostels.Count; i++)
{
    var hostel = _hostels[i];
    var color = colors[i];
    var count = _students.Count(s => s.Hostel == hostel);
    barChart.AddItem(hostel.Name, count, color);
}

AnsiConsole.Write(barChart);
