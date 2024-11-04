# HostelStudents

## Build

dotnet build

## Update database

```bash
dotnet tool install --global dotnet-ef
dotnet ef --project ${app_name}.BusinessLogic --startup-project ${app_name} database update
```

## Run

```bash
dotnet run --project ${app_name}
```

## Test

### terminal window 1

```bash
dotnet tool install --global PowerShell
cd ${app_name}.AcceptanceTests
./bin/Debug/net8.0/playwright.ps1 install --with-deps
cd ..
dotnet run --environment Test --project ${app_name}
```

### terminal window 2

```bash
dotnet test
```
