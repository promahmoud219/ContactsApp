# ADR 0005: Infrastructure Repository Implementation Structure

## Status
Accepted

## Context
In the **ContactsApp** project, which follows **Clean Architecture**, the initial approach was to split the `Repository Implementation` in the `Infrastructure` layer into separate files for each operation:
* `Create.cs`
* `Delete.cs`
* `GetAll.cs`
* `GetContactById.cs`
* `Search.cs`
* `Update.cs`

The purpose of the discussion was to determine whether this granular split was necessary or if it constituted **Over-engineering**.

## Decision
We have decided to consolidate all **CRUD** operations for the `Contact` entity into a single class and file named `ContactRepository.cs` within the `Repositories` folder of the `Infrastructure` layer.

## Rationale
1. **Simplified Dependency Injection:** Instead of repeating the injection of `DatabaseContext` (or Unit of Work) across 6 different files, it is now injected once in the constructor of the consolidated class.
2. **High Cohesion:** Operations that handle the same entity (`Contact`) and rely on the same data source should be grouped together both logically and programmatically.
3. **Maintenance Ease:** The previous multi-file structure mimics a strict **CQRS** pattern, which the current scale of the application does not require. The split added unnecessary navigation overhead.
4. **Interface Alignment:** Since the `Core` layer defines a single `IContactRepository` interface, having a single class implement it is the most natural and standard approach.

## Alternatives
* **Partial Classes:** Using the `partial class` feature to keep operations in separate files while merging them at compile time. This was rejected to keep the folder structure clean and simple.
* **Full CQRS:** Completely separating "Reads" from "Writes." This is reserved as a future option if the project scales significantly or requires different data sources for queries.

## Consequences
* The content of the 6 individual operation files will be merged into `ContactRepository.cs`.
* The number of files in the `Repositories` folder will decrease, making code navigation more intuitive.