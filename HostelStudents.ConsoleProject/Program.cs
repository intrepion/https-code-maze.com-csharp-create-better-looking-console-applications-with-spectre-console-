// See https://aka.ms/new-console-template for more information
using HostelStudents.BusinessLogic.Entities;
using Spectre.Console;

Console.WriteLine("Hello, World!");

Hostel[] _hostels = [
    new Hostel { Name = "Lincoln" },
    new Hostel { Name = "Louisa" },
    new Hostel { Name = "Laurent" },
    new Hostel { Name = "George" },
    new Hostel { Name = "Kennedy" },
];

Student[] _students = [
    new Student { Id = Guid.NewGuid(), FirstName = "Julie", LastName = "Matthew", Age = 19, Hostel = _hostels[0] },
    new Student { Id = Guid.NewGuid(), FirstName = "Michael", LastName = "Taylor", Age = 23, Hostel = _hostels[0] },
    new Student { Id = Guid.NewGuid(), FirstName = "Joe", LastName = "Hardy", Age = 27, Hostel = _hostels[0] },
    new Student { Id = Guid.NewGuid(), FirstName = "Sabrina", LastName = "Azulon", Age = 18, Hostel = _hostels[0] },
    new Student { Id = Guid.NewGuid(), FirstName = "Hunter", LastName = "Cyril", Age = 19, Hostel = _hostels[0] },
];

AnsiConsole.Markup($"[bold blue]Hello[/] [italic green]{_students[1].FirstName}[/]!");
AnsiConsole.Write(new Markup($"[underline #800080]{_students[2].FirstName}[/]"));
AnsiConsole.MarkupLine($"[rgb(128,0,0)]{_students[3].FirstName}[/]");

AnsiConsole.MarkupLine($"[red on yellow] Hello, {_students[4].LastName}![/]");

AnsiConsole.Markup($"[[{_students[3].FirstName}]]");
AnsiConsole.MarkupLine($"[blue][[{_students[3].Hostel}]][/]");
AnsiConsole.MarkupLine($"[{_students[3].Age}]".EscapeMarkup());
