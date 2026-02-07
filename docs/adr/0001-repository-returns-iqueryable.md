# ADR 0001: Repository returns IQueryable instead of IEnumerable

## Status
Accepted

## Context
We need to allow flexible query composition (filtering, paging, projection)
at higher layers without loading unnecessary data into memory.

## Decision
Repositories will return IQueryable<T> for read operations.

## Consequences
- Pros:
  - Deferred execution
  - Better performance for large datasets
  - Enables pagination and projection in UseCases

- Cons:
  - Risk of leaking query logic outside repository
  - Requires discipline to avoid UI-level LINQ

## Notes
UseCases are the only allowed layer to compose queries.
