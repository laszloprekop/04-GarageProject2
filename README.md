# Garage 2.0

A C# terminal application for managing a multi-type vehicle garage. Park and remove cars, motorcycles, buses, boats, and airplanes across multiple garage layouts — complete with a Unicode sprite view rendered live from a text blueprint.

Built as a C# exercise at Lexicon, focused on generics, interfaces, and separation of concerns.

![demo](demo.png)

Each garage is defined as a compact ASCII blueprint. The app parses it into a grid and renders every cell as a Unicode sprite:

```
"░░░░░░░░░░░░░░░░",   ░ = wall      
"░░│C│C│p│p│  bb░",   │ = parking space divider
"░            bb░",   c = car sized parking spot
"░ │C│c│c│p│  bb░",   p = reserved/rented space (reg. number)
"░ ├─┼─┼─┼─┤  ──░",   C/P = has EV charger
"░ │C│c│c│P│  bb░",   b = bus bay
"░            bb░",
"░░│C│C│p│P│  bb░",
"░░░░░░░░░░░  ░░░",
```

Characters encode both cell type and traits — EV charger, reserved flag, vehicle-type restriction — in one place. The renderer expands each logical cell into a proportional Unicode sprite (4×5 for vertical car bays, 9×15 for a full bus zone).

## How to use

```bash
git clone <repo-url>
cd 04-GarageProject2
dotnet run --project Ovn4-GarageProject2
```

Use the **Garage** menu to park vehicles, remove them by registration number, search by colour/wheel count/type, or browse the full parking history. Switch between garages with **Switch Garage** and toggle between the sprite view and the symbol map with **Toggle Renderer**.

## Architecture

- **`Program` → `Manager` → `IUi` / `IHandler`:** `Manager` wires UI and handler through interfaces; business logic never reaches the view layer.
- **`Garage<T>`:** generic collection backed by a `GarageCell[,]` grid; implements `IEnumerable<T>` over parked vehicles.
- **`GarageCell` hierarchy:** `ParkingSpot` | `RoadCell` | `WallCell` — physical layout cells. `ParkingSpot` holds up to three sub-slots (for motorcycles) and an optional vehicle-type restriction.
- **`LayoutParser`:** reads a blueprint `string[]` and returns a fully configured `GarageCell[,]`.
- **`SymbolRenderer`:** fast 1:1 text fallback — each logical cell becomes two unicode characters.
- **`GarageRenderer`:** full sprite renderer — expands cells to proportional character blocks (4×5 car, 9×3 horizontal bay, 9×15 bus zone), auto-detects lane widths and entry facing.
- **`GarageHandler`:** all business logic — park, remove, find, search, parking-session history.
- **Two built-in layouts:** `MixedGarageLayout` (`Garage<Vehicle>`) with car, EV, reserved, and bus bays; `HangarLayout` (`Garage<Airplane>`).

## Phases

- **Phase 0 — Walking skeleton:** project structure, abstract `Vehicle`, stubbed `GarageCell` hierarchy and interfaces, Terminal.Gui window boots.
- **Phase 1 — Complete:** concrete vehicle types, sub-slot motorcycles, `LayoutParser`, two layouts, sprite renderer with bus zone support, park / remove / find / search / history dialogs, parking-session tracking, garage switcher, input validation.
- **Phase 2 — Stretch:** cursor-based interactive parking, live as-you-type search, JSON persistence, vehicle-specific property filters, usage-stats dashboard.

## Dependencies

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
- [Terminal.Gui 2.x](https://github.com/gui-cs/Terminal.Gui) — TUI framework

## Docs

- [Class & sequence diagrams](Ovn4-GarageProject2/Docs/diagrams.md)
- [UI elements](Ovn4-GarageProject2/Docs/UI-elements.md)
