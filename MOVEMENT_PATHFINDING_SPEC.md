# Movement and Pathfinding Implementation Specification

## Overview
This document provides detailed technical specifications for implementing the movement and pathfinding system in X-COM: Generations, building on the existing battlescape framework.

## Current System Analysis

### Existing Components We'll Build Upon
- `Battlescape.cs`: Main battlescape screen with mouse event handling
- `Battle.cs`: Manages selected soldier and unit state
- `BattleSoldier.cs`: Individual soldier with location and stats
- `Map.cs`: Renders the battlescape with isometric projection
- `GameState.Current.PointerPosition`: Mouse coordinate tracking
- `InteractiveDispatcher`: Input event routing system

### Current Coordinate System
- Game resolution: 320x200 pixels
- Isometric tile-based map rendering
- 3D coordinate system with levels (Z-axis)
- Mouse coordinates converted from 960x600 display to 320x200 game coordinates

## Component Architecture

### 1. BattleCursor System

**Purpose**: Visual cursor that follows mouse and indicates interaction possibilities

```csharp
public class BattleCursor : Drawable
{
    public Location CurrentPosition { get; private set; }
    public CursorMode Mode { get; private set; }
    public List<Location> LevelIndicators { get; private set; }
    
    public void Update(Point mousePosition, Map map, BattleSoldier selectedSoldier);
    public void Render(GraphicsBuffer buffer);
    public CursorMode DetermineCursorMode(Location position, Map map, BattleSoldier soldier);
}

public enum CursorMode
{
    Default,           // Standard exploration cursor
    ValidMove,         // Can move to this location (green)
    InvalidMove,       // Cannot move here (red) 
    OutOfRange,        // Beyond movement range (orange)
    FriendlyUnit,      // Another X-COM soldier (blue)
    EnemyUnit,         // Alien or hostile unit (red crosshairs)
    InteractableItem,  // Items, doors, etc. (special icon)
    ElevatedPosition   // Multi-level position with indicators below
}
```

**Visual Design:**
- Primary cursor: 16x16 pixel tile highlight
- Level indicators: Smaller 8x8 indicators on lower levels
- Color coding: Green (valid), Red (invalid), Blue (friendly), etc.
- Animation: Subtle pulsing or animated borders

### 2. Coordinate Transformation System

**Purpose**: Convert between screen coordinates, world coordinates, and map positions

```csharp
public static class CoordinateSystem
{
    public static Location ScreenToWorld(Point screenPos, Map map);
    public static Point WorldToScreen(Location worldPos, Map map);
    public static bool IsValidMapPosition(Location pos, Map map);
    public static float GetElevationAt(Location pos, Map map);
}

public struct Location
{
    public int X { get; set; }  // Map grid X
    public int Y { get; set; }  // Map grid Y  
    public int Z { get; set; }  // Level/elevation
    
    public float Distance(Location other);
    public bool IsAdjacent(Location other);
}
```

### 3. Soldier Selection System

**Purpose**: Handle clicking on soldiers to select them

```csharp
public class SoldierSelection
{
    public BattleSoldier GetSoldierAt(Location position, Battle battle);
    public bool IsSoldierClickable(BattleSoldier soldier, BattleSoldier currentSelection);
    public void SelectSoldier(BattleSoldier soldier, Battle battle);
}
```

**Selection Rules:**
- Left-click on soldier sprite selects that soldier
- Clicking on already selected soldier has no effect
- Visual feedback when hovering over selectable soldiers
- Priority system when multiple units occupy same tile

### 4. Movement Validation System

**Purpose**: Determine if movement to a location is valid

```csharp
public class MovementValidator
{
    public MovementResult ValidateMovement(BattleSoldier soldier, Location target, Map map);
    public int CalculateMovementCost(BattleSoldier soldier, Location target, Map map);
    public bool IsLocationPassable(Location location, Map map, BattleSoldier soldier);
}

public class MovementResult
{
    public bool IsValid { get; set; }
    public int TimeUnitCost { get; set; }
    public string FailureReason { get; set; }
    public List<Location> Path { get; set; }
}
```

**Validation Criteria:**
- Target location is passable terrain
- No obstructions (walls, other units)
- Within soldier's movement range (time units)
- Valid path exists to target
- Soldier has enough time units remaining

### 5. Pathfinding Engine

**Purpose**: Calculate optimal movement paths using A* algorithm

```csharp
public class Pathfinding
{
    public List<Location> FindPath(Location start, Location end, Map map, BattleSoldier soldier);
    public int CalculatePathCost(List<Location> path, Map map, BattleSoldier soldier);
    
    private List<PathNode> GetNeighbors(PathNode node, Map map);
    private float CalculateHeuristic(Location a, Location b);
    private float GetMovementCost(Location from, Location to, Map map, BattleSoldier soldier);
}

public class PathNode
{
    public Location Position { get; set; }
    public float GCost { get; set; }  // Cost from start
    public float HCost { get; set; }  // Heuristic cost to end
    public float FCost => GCost + HCost;
    public PathNode Parent { get; set; }
}
```

**Pathfinding Features:**
- 3D pathfinding supporting multiple levels
- Different movement costs for terrain types
- Obstacle avoidance (walls, units, impassable terrain)
- Optimized for real-time performance
- Support for different unit sizes

### 6. Movement Animation System

**Purpose**: Smoothly animate soldier movement along calculated paths

```csharp
public class MovementAnimation
{
    public bool IsAnimating { get; private set; }
    public Location CurrentPosition { get; private set; }
    public float AnimationProgress { get; private set; }
    
    public void StartMovement(BattleSoldier soldier, List<Location> path);
    public void Update(float deltaTime);
    public void OnAnimationComplete();
}
```

**Animation Features:**
- Smooth interpolation between waypoints
- Soldier facing direction updates during movement  
- Time unit deduction as movement progresses
- Cancellable movement for interruptions
- Sound effects for footsteps

### 7. Path Preview System

**Purpose**: Show planned movement route before execution

```csharp
public class PathPreview : Drawable
{
    public List<Location> PreviewPath { get; private set; }
    public int EstimatedCost { get; private set; }
    
    public void UpdatePreview(Location target, BattleSoldier soldier, Map map);
    public void ClearPreview();
    public void Render(GraphicsBuffer buffer);
}
```

**Preview Features:**
- Dotted line showing movement path
- Time unit cost display
- Different colors for valid/invalid paths
- Updates in real-time as mouse moves

## Integration Points

### Mouse Event Handling

**Extend Battlescape.cs:**
```csharp
public override void OnMouseMove(int row, int column, bool leftButton, bool rightButton)
{
    var mousePosition = new Point(column, row);
    battleCursor.Update(mousePosition, battle.Map, battle.SelectedSoldier);
    pathPreview.UpdatePreview(battleCursor.CurrentPosition, battle.SelectedSoldier, battle.Map);
    base.OnMouseMove(row, column, leftButton, rightButton);
}

public override void OnLeftButtonDown(int row, int column)
{
    var clickPosition = CoordinateSystem.ScreenToWorld(new Point(column, row), battle.Map);
    var clickedSoldier = soldierSelection.GetSoldierAt(clickPosition, battle);
    
    if (clickedSoldier != null)
    {
        soldierSelection.SelectSoldier(clickedSoldier, battle);
    }
    
    base.OnLeftButtonDown(row, column);
}

public override void OnRightButtonDown(int row, int column)
{
    var targetPosition = CoordinateSystem.ScreenToWorld(new Point(column, row), battle.Map);
    var movementResult = movementValidator.ValidateMovement(
        battle.SelectedSoldier, targetPosition, battle.Map);
    
    if (movementResult.IsValid)
    {
        ExecuteMovement(battle.SelectedSoldier, movementResult.Path);
    }
    else
    {
        ShowMovementError(movementResult.FailureReason);
    }
    
    base.OnRightButtonDown(row, column);
}
```

### Rendering Integration

**Extend Battlescape.Render():**
```csharp
public override void Render(GraphicsBuffer buffer)
{
    battle.Map.Render(buffer, battle.Soldiers);
    
    // Render soldier selection indicator
    if (battle.SelectedSoldier != null)
    {
        soldierIndicator.Render(buffer, battle.SelectedSoldier.Location);
    }
    
    // Render path preview
    pathPreview.Render(buffer);
    
    // Render battle cursor (should be on top)
    battleCursor.Render(buffer);
    
    base.Render(buffer);
    DrawUnitInformation(buffer, battle.SelectedUnit);
}
```

## Implementation Timeline

### Day 1-2: Foundation Components
1. Create `CoordinateSystem` class with screen-to-world conversion
2. Implement basic `BattleCursor` with position tracking
3. Add cursor rendering to `Battlescape.Render()`
4. Test mouse coordinate conversion accuracy

### Day 3-4: Visual Cursor System
1. Implement cursor mode determination logic
2. Add visual states for different cursor modes
3. Create multi-level indicator system
4. Add smooth cursor movement and animations

### Day 5-6: Soldier Selection
1. Implement `SoldierSelection` class with hit-testing
2. Add left-click soldier selection to `Battlescape`
3. Create soldier selection indicator visual
4. Test selection with overlapping units

### Day 7-8: Movement Validation
1. Create `MovementValidator` with basic validation rules
2. Implement terrain passability checking
3. Add time unit cost calculations
4. Integrate validation with cursor mode system

### Day 9-11: Pathfinding Engine
1. Implement A* pathfinding algorithm
2. Add 3D pathfinding support for multiple levels
3. Optimize pathfinding performance
4. Test pathfinding with complex terrain

### Day 12-14: Movement Execution
1. Create `MovementAnimation` system
2. Implement smooth movement along paths
3. Add right-click movement command handling
4. Integrate time unit deduction during movement

### Day 15: Integration and Polish
1. Add `PathPreview` system for planned routes
2. Integrate all components into `Battlescape`
3. Add error handling and user feedback
4. Test complete movement workflow

## Testing Strategy

### Unit Tests
- Coordinate transformation accuracy
- Pathfinding algorithm correctness  
- Movement validation logic
- Time unit calculations

### Integration Tests
- Mouse interaction workflow
- Soldier selection and movement
- Multi-level cursor display
- Performance with large maps

### User Experience Tests
- Cursor responsiveness
- Visual clarity of movement options
- Intuitive interaction patterns
- Edge case handling

## Technical Considerations

### Performance Optimization
- Cache pathfinding results for repeated queries
- Use spatial indexing for soldier hit-testing
- Limit pathfinding search depth
- Optimize rendering with dirty region tracking

### Error Handling
- Graceful handling of invalid coordinates
- User-friendly error messages for invalid moves
- Recovery from pathfinding failures
- Validation of all user input

### Extensibility
- Modular design for adding new cursor modes
- Pluggable movement cost calculations
- Support for different unit types and sizes
- Framework for future combat actions

This specification provides a comprehensive foundation for implementing the movement and pathfinding system while maintaining consistency with the existing X-COM: Generations architecture.
