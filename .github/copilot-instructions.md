# X-COM: Generations Development Guide

## Project Overview

This is a C# WinForms rewrite of the original X-COM: UFO Defense using OpenGL rendering. The codebase recreates the original gameplay mechanics with eventual goals for new story content.

## Terminal/Console Commands
This project uses Windows and the PowerShell terminal for commands.

Do:
- Use (;) to chain commands.

Don't:
- Use (&&) to chain commands.

Exmaple:
```PowerShell
cd "path"; dotnet build
```

## Architecture & Core Patterns

### Global Singleton Pattern
- `GameState.Current` is the central singleton managing application state, screens, and data
- Access current game data via `GameState.Current.Data` and selected base via `GameState.SelectedBase`
- All screens and UI components reference this singleton for state management

### Screen Architecture
- All screens inherit from `Screen` base class, which extends `InteractiveContainer`
- Screen switching via `GameState.Current.SetScreen(newScreen)`
- Modal dialogs use `DoModal(parentScreen)` and `EndModal()` pattern
- Focus management handled automatically by `InteractiveDispatcher`

### Interactive System
- UI components implement `Interactive` interface for mouse/keyboard events
- Event handling flows: MainForm → GameState.Dispatcher → Active Screen → Child Controls
- Coordinate system: 320x200 game resolution scaled 3x to 960x600 display
- Mouse coordinates converted from display to game coordinates in MainForm

### Enum-Metadata Pattern
All game entities use strongly-typed enums with extension methods for metadata:
```csharp
WeaponType.Pistol.Metadata()        // Returns WeaponMetadata
FacilityType.Laboratory.Metadata()  // Returns FacilityMetadata
ItemType.LaserRifle.Metadata()      // Returns ItemMetadata
```

### Rendering System
- Custom `GraphicsBuffer` class (320x200) with pixel-level drawing
- Palette-based rendering using original X-COM color palettes
- All `Drawable` objects implement `Render(GraphicsBuffer buffer)`
- OpenGL used only for final buffer display with 3x scaling

### Data Management
- Game state serialized to JSON files (`save{id}.json`)
- `GameData` class contains all persistent game state
- Automatic time progression triggers hourly/daily/monthly game events
- Base management through `Base` class with facilities, soldiers, crafts

## Key Development Workflows

### Building & Running
```PowerShell
dotnet build
dotnet run --project XCom
```

Note that when running the application, it will not exit automatically.
If you want to exit the application, use the following command:
```PowerShell
taskkill /IM XCom.exe /F
```

### Adding New Screens
1. Create class inheriting from `Screen`
2. Override `OnSetFocus()` and `OnKillFocus()` for initialization/cleanup
3. Add UI controls in constructor using `AddControl()`
4. Implement navigation via `GameState.Current.SetScreen()`

### Adding New Game Entities
1. Define enum type (e.g., `NewEntityType`)
2. Create metadata class implementing appropriate interface
3. Add extension class with `Metadata()` method and static dictionary
4. Add content resources in appropriate `Content/` subfolder

### Battlescape System
- Turn-based tactical combat in `Battlescape` namespace
- `Battle` class manages units, turns, and game state
- `Unit` base class extended by `BattleSoldier` for X-COM troops
- Inventory system using `InventoryLocation` enum with time unit costs

## Content Integration

### Resource Management
- All game assets embedded as resources in `Content/` folders
- Auto-generated Designer classes provide typed access to resources
- Images stored as byte arrays with palette indices
- Use `Items.ResourceName` pattern for accessing embedded content

### Graphics Conventions
- Sprites use palette index 0 for transparency (masked rendering)
- Items have both inventory images and ground sprites
- UI elements positioned using absolute pixel coordinates
- Custom drawing methods in `GraphicsBuffer` for primitives and sprites

## Common Patterns

### Modal Dialog Pattern
```csharp
var dialog = new SomeModal();
dialog.DoModal(this);  // 'this' is current screen
```

### Time-Based Updates
Game time advancement triggers cascading updates through `GameData.AdvanceGameTime()`:
- 10-minute intervals: Base operations
- Hourly: Research progress, manufacturing
- Daily: Facility maintenance, soldier recovery  
- Monthly: Funding, country satisfaction

### Error Handling
- Extensive use of `throw new InvalidOperationException()` for invalid states
- Validation methods in project/transfer classes before execution
- TODO comments mark incomplete implementations

## Project Structure Notes

- `Controls/`: Reusable UI components
- `Screens/`: Game screens and major UI flows  
- `Data/`: Game entities and persistence
- `Battlescape/`: Tactical combat system
- `Graphics/`: Rendering and drawing utilities
- `Content/`: Embedded game assets and resources
