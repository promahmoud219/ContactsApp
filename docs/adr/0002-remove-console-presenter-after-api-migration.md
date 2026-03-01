# ADR 0002: Remove Presenter Pattern from Console after API Migration

## Status
Accepted

## Context

Originally, the Console application directly invoked UseCases from the Core layer.
To preserve Clean Architecture boundaries, the Console implemented OutputPort
interfaces (Presenter pattern) defined in the Core.

After introducing WebAPI as the new application host, the architecture changed:

Console ? HTTP ? WebAPI ? UseCase ? Domain

The Console is no longer part of the application boundary.
It is now an external client.

Therefore, the OutputPort abstraction is no longer needed in the Console,
because HTTP responses now serve as the output boundary.

## Decision

Remove Presenter / OutputPort implementations from the Console project.

Console controllers will:
- Call IContactsApiClient
- Receive ClientResult<T>
- Delegate rendering directly to the View

The OutputPort pattern remains inside the Core for internal boundaries only.

## Consequences

### Pros
- Clear separation between Client and Server boundaries
- Eliminates unnecessary abstraction in the Console
- Prevents leaking OperationResult to the Client
- Simplifies presentation flow in the Client

### Cons
- Presentation logic moves slightly closer to Console controllers
- Console is no longer a Clean Architecture delivery mechanism,
  but a thin HTTP client

## Notes

HTTP is now the official output boundary.
The Console is an external consumer, not part of the system core.

Future UI clients (Web, Mobile, etc.) must not depend on Core directly.