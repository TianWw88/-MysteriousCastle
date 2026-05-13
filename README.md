# Mysterious Castle - 3D Horror Escape Room

**Module:** GAME AND MOBILE APP DEVELOPMENT Coursework
**Unity Version:** 6000.3.9f1 (Unity 6)

## Overview
A first-person 3D escape-room game with 5 levels, featuring puzzle-solving, 
AI-driven guard NPCs, and a maze-evasion finale.

## Features
- 5 levels with progressive difficulty
- Finite State Machine (FSM) guard AI with NavMesh pathfinding
- Multiple puzzle types: password locks, slider mechanisms, jigsaw minigame
- Health and damage system
- Complete UI: HUD, pause menu, win/lose screens

## How to Run
1. Open the project in Unity 6 (6000.3.9f1)
2. Open `Assets/bgm.unity` as the starting scene
3. Press Play

**Note:** This project was developed in Unity 6. Earlier Unity versions 
(2022 or below) may not open the project correctly.

## Controls
- **WASD** - Move
- **Hold Right Mouse Button + Move Mouse** - Look around
- **Left Click** - Interact with objects
- **Space** - Pause menu
- **ESC** - Close puzzle UI

## Scene Structure
- `bgm.unity` - Audio initialization
- `Start.unity` - Main menu
- `Level0.unity` - Level 1 (TV password puzzle, code 0812)
- `Level2.unity` - Level 2 (drawer search and hidden key)
- `Level3.unity` - Level 3 (multi-clue puzzle: wind chime, slider lock, pattern code)
- `Level4.unity` - Level 4 (safe code 0481, jigsaw puzzle, guard chase)
- `Level5.unity` - Level 5 (maze escape with guard evasion)

Note: Scene file naming starts from Level0 due to early prototyping.

## External Assets
- **Polygon Horror Mansion** by Synty Studios - Unity Asset Store
- **Toony Tiny People** - Unity Asset Store  
- **Quick Outline** by Chris Nolet - https://github.com/chrisnolet/QuickOutline
- **Background music, fonts, and UI icons** - https://www.aigei.com

All game scripts (player controller, guard AI, level logic, puzzle mechanics, 
UI panels) are original work by the author.

## Project Structure
- `Assets/C#/` - Core game scripts (player controller, AI, level logic)
- `Assets/Scripts/` - UI panels and jigsaw puzzle minigame
- `Assets/Level3/`, `Level4/`, `Level5/`, `Main/` - Scene baking data (lighting, navmesh)

## Technical Highlights
- Finite State Machine for guard AI (Patrol → Chase → Attack)
- Unity NavMesh for pathfinding around obstacles
- Animator Controller (Mecanim) driving guard animations via SetBool
- Raycast-based player interaction with scene objects
- Scene-wide state management with timeScale handling across transitions
