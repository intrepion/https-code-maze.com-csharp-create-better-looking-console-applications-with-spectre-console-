# HostelStudents

## Build

dotnet build

## Update database

```bash
dotnet tool install --global dotnet-ef
dotnet ef --project HostelStudents.BusinessLogic --startup-project HostelStudents migrations add <<NewScriptName>>
```

## Update database

```bash
dotnet tool install --global dotnet-ef
dotnet ef --project HostelStudents.BusinessLogic --startup-project HostelStudents database update
```

## Run

```bash
dotnet run --project HostelStudents --urls http://localhost:8765
```

## Test

### terminal window 1

```bash
dotnet tool install --global PowerShell
cd HostelStudents.AcceptanceTests
pwsh ./bin/Debug/net8.0/playwright.ps1 install --with-deps
cd ..
dotnet run --environment Test --project HostelStudents --urls http://localhost:8765
```

### terminal window 2

```bash
BASE_URL=http://localhost:8765 HEADED=1 dotnet test
```

## Generate Test Code

### terminal window 2

```bash
cd HostelStudents.AcceptanceTests
pwsh ./bin/Debug/net8.0/playwright.ps1 codegen http://localhost:8765
cd ..
```
