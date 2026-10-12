# Maintenance Parts Organizer

A Windows desktop application for tracking a maintenance department's parts inventory. Technicians can log parts as they are bought, remove them as they are used, and see right away which parts are running low and need to be reordered.

Built with **C#**, **.NET 8 (Windows Forms)**, and **SQLite**.

## Why I built it

The maintenance department at my workplace needed a simple, reliable way to know what parts were on hand. This tool replaces guesswork with one up-to-date list of every part, its part number, and how many are in stock.

## Features

- **Add parts.** Enter a part name, part number, and quantity. If the part number already exists, the quantity is added to the existing stock instead of creating a duplicate entry.
- **Remove parts.** Subtract a used quantity by part number. When a part's stock reaches zero, it is removed from the inventory automatically. Unknown part numbers show a clear error message.
- **View inventory.** See every part with its name, number, and quantity. The list refreshes automatically when you return to the window.
- **Low-stock alerts.** Any part with 3 or fewer units left is flagged in a separate warnings list so it can be reordered before it runs out.
- **Consistent data entry.** Part numbers are stored in uppercase, and part names are formatted consistently, so the same part is never entered two different ways.
- **Safe database access.** All queries use parameterized SQL to protect against SQL injection.

## Tech stack

| Area | Technology |
|---|---|
| Language | C# |
| Framework | .NET 8, Windows Forms |
| Database | SQLite via `Microsoft.Data.Sqlite` |
| IDE | Visual Studio |

## Project structure

```
MaintenanceOrganizer/
├── Program.cs               # Application entry point
├── MainMenuForm.cs          # Main menu: Add, View, and Remove Parts
├── AddDataForm.cs           # Add new parts or restock existing ones
├── DeleteDataForm.cs        # Remove used parts from inventory
├── ViewDatabaseForm.cs      # Inventory list and low-stock warnings
├── DatabaseManager.cs       # All SQLite data access (create, insert, update, query, delete)
└── NonDatabaseFunctions.cs  # Input formatting helpers
```

## Getting started

### Requirements

- Windows 10 or 11
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 (optional)

### Run it

```bash
git clone https://github.com/KylleWaldie/Maintenance-Organizer.git
cd Maintenance-Organizer/MaintenanceOrganizer
dotnet run
```

Or open `MaintenanceOrganizer.sln` in Visual Studio and press **F5**.

The SQLite database file (`PartsDatabase.db`) is created automatically the first time a part is added.

## Roadmap

- Sort and filter the inventory by part number or part type
- Move from a local SQLite file to a cloud-hosted database, so the inventory can be shared across multiple computers
- Add input validation for quantities and required fields
- Add unit tests for the database layer

## Author

**Kylle Waldie** · [github.com/KylleWaldie](https://github.com/KylleWaldie)
