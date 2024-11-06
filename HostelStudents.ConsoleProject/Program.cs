// See https://aka.ms/new-console-template for more information
using HostelStudents.BusinessLogic.Entities;

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
