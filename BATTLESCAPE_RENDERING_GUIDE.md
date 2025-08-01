# Battlescape Rendering System Documentation

## Overview

The battlescape uses an isometric 3D rendering system to display tactical combat maps. This document explains the coordinate systems, rendering order, and visual representation used throughout the battlescape.

## Coordinate Systems

### Map Coordinates (MapLocation)
Each location in the battlescape is represented by a `MapLocation` with three properties:
- **Level**: Vertical layer (0 to Levels - 1), where 0 is the bottom level
- **Row**: North-South position (0 to Height - 1)  
- **Column**: East-West position (0 to Width - 1)

**Notation**: MapLocation can be written as `(Level, Row, Column)`
**Example**: `(0, 1, 2)` = Level 0, Row 1, Column 2

### Graphics Buffer Coordinates
The final rendered position on the 320x200 screen buffer, calculated from:
- **Map.RowOffset**: Base Y coordinate for map location (0,0,0)
- **Map.ColumnOffset**: Base X coordinate for map location (0,0,0)

### Coordinate Transformation Formulas

```csharp
// From MapLocation to Graphics Buffer coordinates
int graphicsX = Map.ColumnOffset + (column * 16) - (row * 16);
int graphicsY = Map.RowOffset + (-24 * level) + (column * 8) + (row * 8);
```

**Movement Patterns**:
- **Column + 1**: X + 16, Y + 8 (moving NorthEast)
- **Row + 1**: X - 16, Y + 8 (moving SouthEast)  
- **Level + 1**: X + 0, Y - 24 (moving up)

## Isometric View Layout

### Direction Mapping
The 8 compass directions map to the isometric view as follows:
- **North**: Up and to the right (↗)
- **NorthEast**: Right (→)
- **East**: Down and to the right (↘)
- **SouthEast**: Down and to the left (↙)
- **South**: Down and to the left (↙)
- **SouthWest**: Left (←)
- **West**: Up and to the left (↖)
- **NorthWest**: Up and to the right (↗)

### Tile Geometry
Each map location is rendered as a 32×40 pixel sprite representing an isometric cube:

```
    NW ---- NE
   /  \    /  \
  /    \  /    \
 /      \/      \
SW ---- SE ---- 
 \      /\      /
  \    /  \    /
   \  /    \  /
    \/      \/
```

**Key Points** (relative to top-left of 32×40 sprite):
- **NorthWest corner**: (16, 0) - top center
- **NorthEast corner**: (32, 8) - right edge, 8px down
- **SouthEast corner**: (16, 16) - center, 16px down  
- **SouthWest corner**: (0, 8) - left edge, 8px down

## Rendering Architecture

### Level Rendering Order
1. **Bottom level first**: Level 0 rendered before Level 1, etc.
2. **Selected level limit**: Only levels 0 through `Map.SelectedLevelIndex` are rendered (unless full-map mode is active)
3. **Full-map mode**: When enabled via `Battlescape.OnToggleLevelView()`, all levels render

### Within-Level Rendering Order  
For each level, map locations are drawn in this order:
1. **Column order**: Left to right (Column 0 to Width - 1)
2. **Row order**: Top to bottom (Row 0 to Height - 1)

This ensures proper sprite layering for the isometric view.

### Tile Component Rendering Order
For each individual map location, sprites are drawn in this sequence:
1. **Ground** surface (floor/terrain)
2. **North Wall** 
3. **West Wall**
4. **Entity** (non-moving objects like lamp posts) OR **Unit** (soldiers/aliens)

**Note**: A location never has both an Entity and a Unit - entities block unit movement.

## Soldier Indicator Implementation

### Positioning Rules
The soldier indicator should be rendered as if it exists in the level **above** the selected soldier:

```csharp
// Indicator positioning
int indicatorLevel = soldier.Location.Level + 1;
int indicatorRow = soldier.Location.Row;
int indicatorColumn = soldier.Location.Column;
```

### Rendering Context
1. **If level above is being rendered**: Draw indicator after Ground but before any Entity/Unit in that level
2. **If level above is not being rendered**: Still draw the indicator, but without other level components
3. **If soldier is on top level**: Draw indicator as if there's an empty level above

### Integration with Map Rendering
The indicator should integrate with the existing `Level.Render()` method, respecting the same coordinate transformations and visibility bounds checking.

## Map Rendering Flow

```csharp
// Simplified rendering flow
public void Render(GraphicsBuffer buffer, IReadOnlyCollection<BattleSoldier> soldiers)
{
    foreach (var levelIndex in Enumerable.Range(0, SelectedLevelIndex + 1))
    {
        var levelSoldiers = soldiers.Where(s => s.Location.Level == levelIndex).ToList();
        var levelTopRow = -24 * levelIndex + RowOffset;
        var levelLeftColumn = ColumnOffset;
        
        Levels[levelIndex].Render(buffer, levelTopRow, levelLeftColumn, levelSoldiers);
        
        // Soldier indicators would be rendered here for soldiers in levelIndex - 1
    }
}
```

## Bounds Checking

All rendering must respect the 320×200 graphics buffer bounds:

```csharp
// Standard bounds check
var bottom = top + 40;
var right = left + 32;
if (bottom < 0 || right < 0 || top >= 200 || left >= 320)
    continue; // Skip rendering
```

## Mouse Interaction

Mouse interactions operate only on the currently selected level (`Map.SelectedLevelIndex`). The coordinate transformation from screen coordinates to map coordinates must account for:
- Current map scroll position (RowOffset, ColumnOffset)  
- Active level offset (-24 pixels per level)
- Isometric projection mathematics

## Performance Considerations

- **Visibility culling**: Skip rendering sprites that are completely outside the 320×200 view
- **Level limiting**: Only render levels up to SelectedLevelIndex unless in full-map mode
- **Sprite batching**: Group sprite operations where possible
- **Coordinate caching**: Pre-calculate frequently used coordinate transformations

This rendering system maintains the authentic X-COM isometric view while providing smooth scrolling and multi-level tactical combat visualization.
