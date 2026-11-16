# ServiceRecords Index HumanCost Error - Resolution Summary

## Problem
When accessing the ServiceRecords/Index page, a SQLite exception occurred:
```
SqliteException: SQLite Error 1: 'no such column: m.HumanCost'
```

## Root Cause
**Database schema mismatch**: The `MaintenanceItem` model had two fields defined (`HumanCost` and `RawCost`), but the corresponding database table was missing these columns. This mismatch occurred because:

1. The model was updated with new properties:
   ```csharp
   public decimal RawCost { get; set; }
   public decimal HumanCost { get; set; }
   ```

2. However, no Entity Framework Core migration was created and applied to update the SQLite database schema.

3. When the Index.cshtml.cs page tried to load ServiceRecords with its included MaintenanceItem relationships, EF Core generated a query that referenced `m.HumanCost`, but the column didn't exist in the database.

## Solution Applied

### Step 1: Create Migration
Generated a new migration to add the missing columns:
```bash
dotnet ef migrations add AddHumanCostAndRawCostToMaintenanceItem
```

This created:
- `Migrations/20261108222827_AddHumanCostAndRawCostToMaintenanceItem.cs`
- `Migrations/20261108222827_AddHumanCostAndRawCostToMaintenanceItem.Designer.cs`

### Step 2: Apply Migration
Applied the migration to the database:
```bash
dotnet ef database update
```

The migration executed:
```sql
ALTER TABLE "MaintenanceItems" ADD "HumanCost" TEXT NOT NULL DEFAULT '0.0';
ALTER TABLE "MaintenanceItems" ADD "RawCost" TEXT NOT NULL DEFAULT '0.0';
```

### Step 3: Update UI Form
Updated `Pages/MaintenanceItems/Create.cshtml` to include input fields for the new cost properties:
- Added RawCost input field (number, 2 decimal places)
- Added HumanCost input field (number, 2 decimal places)

## Verification
✅ The ServiceRecords/Index page now loads successfully without errors
✅ Users can now input RawCost and HumanCost when creating MaintenanceItems
✅ The database schema is now synchronized with the entity model

## Key Lesson
Always remember to create and apply migrations after modifying Entity Framework Core models. The EF Core model and the database schema must stay in sync. Use:
```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```
