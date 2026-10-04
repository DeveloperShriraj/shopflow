# Contributing to ShopFlow
## Branching
- `main` is always deployable and protected.
- Branch names: `feat/<scope>-<desc>`, `fix/...`, `docs/...`, `chore/...`
- Branches live less than 3 days. Rebase on main before opening a PR.
## Commits (Conventional Commits)
- `feat(catalog): add product search`
- `fix(basket): prevent negative quantity`
- Types: feat, fix, docs, refactor, test, chore, ci, perf
## Pull requests
- Squash merge only. The PR title becomes the commit message.
- CI must be green. Link the issue: `Closes #12`