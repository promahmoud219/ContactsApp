# 0003 — Application Controller for Console Navigation

## Status
Accepted

## Decision
ConsoleUI adopts an Application Controller to centralize navigation and workflow decisions.

## Rationale
Feature controllers handle only a single feature (input + API call) and return `ClientResult<T>`.  
They do not decide what happens next.  
ApplicationController interprets results and determines navigation (e.g., return to menu or go to another feature).  
This prevents feature coupling and duplicated flow logic.  
Navigation is considered application-level behavior, not feature-level behavior.  
Trade-off: slightly more structure in exchange for better scalability and maintainability.

so Feature controllers never call each other directly.

this approach is by Martin Fowler's Application Controller pattern, 
which is widely used in MVC frameworks to centralize control flow and navigation decisions.