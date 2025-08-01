# X-COM: Generations - Project Completion Plan

## Current State Assessment

### ✅ Implemented Core Systems
- **Architecture Foundation**: Complete singleton pattern, screen management, interactive system
- **Geoscape Management**: World view, base management, time progression, UFO tracking
- **Strategic Layer**: Research system, manufacturing, transfers, soldiers, crafts
- **UI Framework**: Complete control system, rendering pipeline, modal dialogs
- **Content Pipeline**: Resource management, palette-based graphics, embedded assets
- **Save/Load System**: JSON serialization, game state persistence
- **Audio System**: Music and sound effect playback

### ⚠️ Partially Implemented
- **Battlescape System**: Basic framework exists but missing core combat mechanics
- **Inventory System**: UI exists but limited ground item handling
- **AI System**: No alien/enemy AI implementation
- **Mission Generation**: Basic map creation but no mission-specific logic

### ❌ Missing Critical Features
- **Combat Mechanics**: Shooting, damage calculation, line of sight, pathfinding
- **Turn Management**: Complete turn-based combat flow
- **Alien Behavior**: All alien AI and movement
- **Mission Objectives**: Win/lose conditions, terror missions, base defense
- **Advanced Features**: Psionics, special weapons, destructible terrain

## Phase 1: Combat System Foundation (4-6 weeks)

### Priority 1A: Movement and Pathfinding (2-3 weeks)

#### Week 1: Visual Foundation and Input Handling

**Day 1-2: Soldier Selection Indicator**
- [ ] Create visual indicator above selected soldier (arrow, highlight ring, or pulsing effect)
- [ ] Update indicator position when soldier selection changes
- [ ] Handle indicator visibility during map scrolling
- [ ] Add animation/pulsing effect to make selection clear

**Key Files to Create/Modify:**
- `XCom/Battlescape/SoldierIndicator.cs` (new)
- `XCom/Battlescape/Battlescape.cs` (add indicator rendering)
- `XCom/Graphics/BattleVisuals.cs` (new - visual effect helpers)

**Day 3-4: Interactive Battle Cursor**
- [ ] Implement cursor that highlights map squares under mouse
- [ ] Show cursor at correct world coordinates (accounting for isometric projection)
- [ ] Handle cursor visibility on different terrain types
- [ ] Add smooth cursor movement and visual feedback

**Key Files to Create/Modify:**
- `XCom/Battlescape/BattleCursor.cs` (new)
- `XCom/Battlescape/CoordinateSystem.cs` (new - screen to world conversion)
- `XCom/Battlescape/Battlescape.cs` (integrate cursor rendering and mouse handling)

**Day 5: Multi-Level Cursor Display**
- [ ] Show cursor indicators on levels below current mouse position
- [ ] Implement "column highlight" effect for elevated positions
- [ ] Add visual distinction between primary cursor and level indicators
- [ ] Handle cursor display when hovering over multi-level terrain

**Key Files to Create/Modify:**
- `XCom/Battlescape/BattleCursor.cs` (expand for multi-level display)
- `XCom/Battlescape/LevelIndicator.cs` (new)

#### Week 2: Mouse Interaction and Movement Planning

**Day 1-2: Soldier Selection by Click**
- [ ] Implement left-click to select soldier at cursor position
- [ ] Add hit-testing for soldier sprites (accounting for isometric view)
- [ ] Handle selection priority when multiple units overlap
- [ ] Provide visual feedback for clickable soldiers (hover effects)

**Key Files to Create/Modify:**
- `XCom/Battlescape/SoldierSelection.cs` (new)
- `XCom/Battlescape/Battlescape.cs` (handle mouse click events)
- `XCom/Battlescape/HitTesting.cs` (new - determine what's under mouse)

**Day 3-4: Movement Target Validation**
- [ ] Implement basic movement validation (can unit reach target?)
- [ ] Check for obstacles (walls, other units, impassable terrain)
- [ ] Validate movement within time unit constraints
- [ ] Show different cursor states: valid move, invalid move, out of range

**Key Files to Create/Modify:**
- `XCom/Battlescape/MovementValidator.cs` (new)
- `XCom/Battlescape/BattleCursor.cs` (add cursor state modes)
- `XCom/Battlescape/TerrainAnalysis.cs` (new - terrain passability)

**Day 5: Basic Movement Command**
- [ ] Implement right-click to attempt movement
- [ ] Show movement path preview when hovering over valid targets
- [ ] Display time unit cost for planned movement
- [ ] Handle invalid movement attempts with user feedback

**Key Files to Create/Modify:**
- `XCom/Battlescape/MovementPlanner.cs` (new)
- `XCom/Battlescape/Battlescape.cs` (handle right-click movement)
- `XCom/Battlescape/PathPreview.cs` (new - show planned route)

#### Week 3: Pathfinding and Movement Execution

**Day 1-3: A* Pathfinding Implementation**
- [ ] Implement A* algorithm for battlescape grid
- [ ] Handle 3D pathfinding with multiple levels
- [ ] Account for unit size and terrain passability
- [ ] Optimize pathfinding performance for real-time use

**Key Files to Create/Modify:**
- `XCom/Battlescape/Pathfinding.cs` (new)
- `XCom/Battlescape/PathNode.cs` (new)
- `XCom/Battlescape/MovementCost.cs` (new - calculate movement costs)
- `XCom/Battlescape/TerrainGraph.cs` (new - represent walkable terrain)

**Day 4-5: Movement Animation and Execution**
- [ ] Implement smooth movement animation along calculated path
- [ ] Handle soldier facing direction during movement
- [ ] Update soldier position in battle state during movement
- [ ] Deduct time units as movement progresses

**Key Files to Create/Modify:**
- `XCom/Battlescape/MovementAnimation.cs` (new)
- `XCom/Battlescape/BattleSoldier.cs` (add movement methods)
- `XCom/Battlescape/Battle.cs` (update unit positions)

#### Advanced Cursor System Design

**Cursor Display Modes:**
```csharp
public enum CursorMode
{
    Default,           // Basic map exploration
    ValidMove,         // Can move here (green highlight)
    InvalidMove,       // Cannot move here (red highlight)
    OutOfRange,        // Beyond movement range (orange/yellow)
    EnemyTarget,       // Enemy unit (crosshairs)
    FriendlyUnit,      // Friendly unit (blue highlight)
    InteractableItem,  // Ground items, doors (special icon)
    ElevatedPosition   // Multi-level indicator
}
```

**Cursor Visual Components:**
- Primary cursor: Highlights current tile
- Level indicators: Show on lower levels for elevated positions
- Path preview: Dotted line showing planned movement route
- Cost indicator: Shows time unit cost for movement
- Action icons: Different icons for different available actions

**Mouse Interaction Flow:**
1. **Mouse Move**: Update cursor position, determine cursor mode, show path preview
2. **Left Click**: Select unit, interact with objects, or confirm actions
3. **Right Click**: Attempt movement or show context menu for advanced actions
4. **Mouse Hover**: Show tooltips, highlight interactive elements

#### Integration with Existing Systems

**Leverage Current Architecture:**
- Use existing `Interactive` interface for mouse handling
- Integrate with `GraphicsBuffer` rendering system
- Follow established coordinate transformation patterns
- Use `GameState.Current.PointerPosition` for mouse tracking

**Build on Existing Components:**
- Extend `Battlescape.cs` mouse event handlers
- Use current soldier selection from `Battle.cs`
- Integrate with existing map rendering in `Map.cs`
- Follow patterns from `HoverScroll.cs` for input handling

#### Testing and Validation

**Unit Tests:**
- Pathfinding algorithm correctness
- Movement validation logic
- Coordinate transformation accuracy
- Cursor state transitions

**Integration Tests:**
- Mouse-to-world coordinate conversion
- Soldier selection by clicking
- Movement command execution
- Multi-level cursor display

**User Experience Tests:**
- Cursor responsiveness and accuracy
- Visual clarity of movement options
- Intuitive interaction patterns
- Performance with complex terrain

**Key Files to Create/Modify:**
- `XCom/Battlescape/Pathfinding.cs` (new)
- `XCom/Battlescape/MovementCalculator.cs` (new)
- `XCom/Battlescape/Unit.cs` (expand movement methods)
- `XCom/Battlescape/Battlescape.cs` (handle movement commands)
- `XCom/Battlescape/BattleCursor.cs` (new)
- `XCom/Battlescape/SoldierSelection.cs` (new)
- `XCom/Battlescape/MovementValidator.cs` (new)
- `XCom/Battlescape/MovementAnimation.cs` (new)

### Priority 1B: Line of Sight and Visibility
- [ ] Implement line of sight calculations
- [ ] Add fog of war system
- [ ] Create visibility updates based on unit positions
- [ ] Handle door opening/closing visibility changes

**Key Files to Create/Modify:**
- `XCom/Battlescape/LineOfSight.cs` (new)
- `XCom/Battlescape/VisibilityManager.cs` (new)
- `XCom/Battlescape/Map.cs` (add visibility methods)

### Priority 1C: Basic Combat Actions
- [ ] Implement weapon firing mechanics
- [ ] Add hit/miss calculations based on accuracy
- [ ] Create damage calculation system
- [ ] Add basic animation for shooting
- [ ] Implement time unit consumption for actions

**Key Files to Create/Modify:**
- `XCom/Battlescape/CombatCalculator.cs` (new)
- `XCom/Battlescape/WeaponSystem.cs` (new)
- `XCom/Battlescape/BattleSoldier.cs` (add combat methods)
- `XCom/Data/WeaponType.cs` (expand metadata)

## Phase 2: Turn Management and AI (3-4 weeks)

### Priority 2A: Complete Turn System
- [ ] Implement proper turn phases (X-COM → Alien → Civilian)
- [ ] Add end-turn validation and cleanup
- [ ] Create turn transition animations
- [ ] Handle unit state reset between turns
- [ ] Implement reaction fire system

**Key Files to Create/Modify:**
- `XCom/Battlescape/TurnManager.cs` (new)
- `XCom/Battlescape/Battle.cs` (complete turn logic)
- `XCom/Battlescape/ReactionFire.cs` (new)

### Priority 2B: Basic Alien AI
- [ ] Create alien unit types and basic AI behaviors
- [ ] Implement alien movement AI (seek cover, approach targets)
- [ ] Add alien shooting AI with target prioritization
- [ ] Create alien patrol and search behaviors
- [ ] Implement basic alien unit spawning

**Key Files to Create/Modify:**
- `XCom/Battlescape/AlienAI.cs` (new)
- `XCom/Battlescape/AlienUnit.cs` (new)
- `XCom/Data/AlienType.cs` (expand with combat stats)
- `XCom/Battlescape/Battle.cs` (integrate alien units)

### Priority 2C: Mission Infrastructure
- [ ] Complete mission win/lose condition checking
- [ ] Implement proper mission completion flow
- [ ] Add score calculation and reporting
- [ ] Create post-mission cleanup and item recovery
- [ ] Handle soldier injuries and deaths

**Key Files to Create/Modify:**
- `XCom/Battlescape/MissionObjectives.cs` (new)
- `XCom/Battlescape/PostMission.cs` (new)
- `XCom/Screens/MissionDebrief.cs` (new)

## Phase 3: Advanced Combat Features (4-5 weeks)

### Priority 3A: Special Weapons and Equipment
- [ ] Implement grenades and explosive weapons
- [ ] Add area-of-effect damage calculations
- [ ] Create special ammunition types (incendiary, armor-piercing)
- [ ] Implement support equipment (motion scanner, medi-kit)
- [ ] Add proper ammunition management

**Key Files to Create/Modify:**
- `XCom/Battlescape/ExplosiveSystem.cs` (new)
- `XCom/Battlescape/SpecialEquipment.cs` (new)
- `XCom/Data/AmmunitionType.cs` (expand functionality)

### Priority 3B: Advanced Mechanics
- [ ] Implement proper armor and damage resistance
- [ ] Add fire and smoke effects
- [ ] Create destructible terrain system
- [ ] Implement door mechanics (opening/closing/destruction)
- [ ] Add proper inventory ground placement in combat

**Key Files to Create/Modify:**
- `XCom/Battlescape/TerrainDestruction.cs` (new)
- `XCom/Battlescape/EnvironmentalEffects.cs` (new)
- `XCom/Battlescape/Inventory.cs` (complete ground item logic)

### Priority 3C: Psionics and Mind Control
- [ ] Implement psionic strength and skill calculations
- [ ] Add mind control and panic mechanics
- [ ] Create psionic combat interface
- [ ] Implement alien psionic abilities
- [ ] Add proper psionic equipment handling

**Key Files to Create/Modify:**
- `XCom/Battlescape/PsionicSystem.cs` (new)
- `XCom/Data/Soldier.cs` (add psionic stats)
- `XCom/Battlescape/MindControl.cs` (new)

## Phase 4: Mission Variety and Polish (3-4 weeks)

### Priority 4A: Mission Types
- [ ] Implement terror missions with civilians
- [ ] Create X-COM base defense missions
- [ ] Add alien base assault missions
- [ ] Implement proper mission briefing system
- [ ] Create mission-specific map generation

**Key Files to Create/Modify:**
- `XCom/Battlescape/MissionTypes/` (new directory)
- `XCom/Battlescape/TerrorMission.cs` (new)
- `XCom/Battlescape/BaseDefense.cs` (new)
- `XCom/Battlescape/AlienBaseAssault.cs` (new)

### Priority 4B: UFO Missions and Crash Sites
- [ ] Complete UFO crash site generation
- [ ] Implement UFO landing site missions
- [ ] Add proper UFO component recovery
- [ ] Create UFO-specific alien spawning
- [ ] Handle different UFO types and layouts

**Key Files to Create/Modify:**
- `XCom/Battlescape/UfoMission.cs` (new)
- `XCom/Battlescape/MapFactory.cs` (complete UFO logic)
- `XCom/Data/UfoType.cs` (expand mission data)

### Priority 4C: UI Polish and Visualization
- [ ] Complete all battlescape UI buttons and functions
- [ ] Add proper battle animations and effects
- [ ] Implement camera following and smooth scrolling
- [ ] Add visual feedback for all combat actions
- [ ] Create proper targeting cursors and indicators

**Key Files to Modify:**
- `XCom/Battlescape/Battlescape.cs` (complete all TODO items)
- `XCom/Graphics/` (animation and effect classes)
- `XCom/Battlescape/BattleAnimations.cs` (new)

## Phase 5: Integration and Testing (2-3 weeks)

### Priority 5A: System Integration
- [ ] Complete geoscape → battlescape → geoscape flow
- [ ] Implement proper equipment persistence
- [ ] Add complete research unlock progression
- [ ] Test all save/load scenarios with battles
- [ ] Balance difficulty and scoring systems

### Priority 5B: Performance and Stability
- [ ] Optimize rendering pipeline for smooth gameplay
- [ ] Fix memory leaks and performance bottlenecks
- [ ] Add comprehensive error handling
- [ ] Test edge cases and boundary conditions
- [ ] Create automated testing for core mechanics

### Priority 5C: Final Polish
- [ ] Complete all remaining TODO items
- [ ] Add missing sound effects and animations
- [ ] Balance weapon stats and alien capabilities
- [ ] Create comprehensive game manual/help system
- [ ] Prepare for initial release

## Development Guidelines

### Code Quality Standards
- Maintain existing architectural patterns (singleton, screen management, enum-metadata)
- Use established naming conventions and code organization
- Add comprehensive error handling with meaningful exceptions
- Document complex algorithms and design decisions
- Write unit tests for combat calculations and AI logic

### Testing Strategy
- Create automated tests for pathfinding and line of sight
- Test combat calculations with known scenarios
- Validate save/load functionality with active battles
- Performance test with large battles (20+ units)
- User test mission flow and difficulty balance

### Risk Mitigation
- **Technical Risk**: Combat calculations complexity
  - **Mitigation**: Start with simplified mechanics, iterate based on testing
- **Scope Risk**: Feature creep and over-engineering
  - **Mitigation**: Focus on core X-COM mechanics first, advanced features later
- **Performance Risk**: Real-time pathfinding and AI
  - **Mitigation**: Implement efficient algorithms, profile early and often

## Success Criteria

### Minimum Viable Product (MVP)
- [ ] Complete X-COM vs Alien tactical combat
- [ ] Basic mission types working (UFO crash/landing)
- [ ] All core weapons and equipment functional
- [ ] Save/load works with active battles
- [ ] Smooth geoscape ↔ battlescape transitions

### Full Feature Complete
- [ ] All original X-COM mission types
- [ ] Complete alien AI with varied behaviors
- [ ] All advanced features (psionics, destructible terrain)
- [ ] Balanced difficulty progression
- [ ] Polish level matching original game

## Estimated Timeline: 16-22 weeks
This timeline assumes 1-2 developers working part-time (20-30 hours/week). Full-time development could reduce this to 8-12 weeks.

The project has excellent foundations and many core systems already in place. The main challenge is implementing the complex tactical combat system while maintaining the quality and architectural patterns already established.
