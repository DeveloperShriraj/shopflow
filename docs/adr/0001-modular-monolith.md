# ADR-0001: Start as a modular monolith
- Status: Accepted
- Date: <today>
## Context
ShopFlow has several business areas (Catalog, Basket, Ordering, Identity).
One developer, early stage, requirements still changing. Microservices bring
network failures, distributed transactions, and per-service deployment cost.
## Decision
Build a single deployable modular monolith. Each module has Clean Architecture
layers (Domain, Application, Infrastructure, Presentation). Modules talk only
through public contracts or integration events, never through each other's
internals or tables.
## Consequences
+ Simple deployment, debugging, and transactions; fast to build.
+ Clear boundaries make later extraction cheap.
- Requires discipline: enforce boundaries with architecture tests (Week 7).
- All modules scale together until a module is extracted.
Revisit when: a module needs independent scaling or a separate team/release cadence.