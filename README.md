<img width="1878" height="1042" alt="2" src="https://github.com/user-attachments/assets/6b295f22-9c9b-4af7-9c77-bbc6e12ba75a" />
# Tower Defence

A 2D tower defence game built in C# with MonoGame. The game has a world map, multiple hand-authored levels, upgradeable tower paths, hero units, player powers, enemy waves, save progress, music, sound effects, and pixel-art content.

## Features

- World-map progression with unlockable level nodes.
- Eight scene-based levels: Forest entrance, Plain fields, Town of Durin, Dark Forest, River cross, Town, Abyss, and Abyss bridge.
- Multiple level modes in the scene system, including normal, special, and endless-style wave loading.
- Build plots with radial tower build and upgrade menus.
- Tower families for archers, mages, bombs, chaos, soul, necromancy, soldiers, and special variants like fire, sniper, missile, electro, death, beam, and castle/viking soldier towers.
- Monster waves loaded from text files, with different enemy types including fast, armored, spawning, teleporting, boss, cave, and slime enemies.
- Hero system with selectable heroes, XP, levels, unlocks, and hero powers.
- Player powers such as meteor strikes and summoned soldiers, with additional power classes for slow bombs and fire oil.
- Star upgrades, tower unlocks, enemy discovery, audio settings, fullscreen settings, and save-file persistence.
- MonoGame content pipeline for sprites, maps, fonts, music, and sound effects.
<img width="1410" height="947" alt="tower1" src="https://github.com/user-attachments/assets/02379811-898b-4818-b428-b5f1cc8aa193" />
<img width="966" height="937" alt="4" src="https://github.com/user-attachments/assets/c7e41321-26c7-4be2-9c4b-53f780e671e3" />
<img width="575" height="528" alt="3" src="https://github.com/user-attachments/assets/4bb8e839-3387-4b18-a7cc-49b47064969b" />

## Controls

| Input | Action |
| --- | --- |
| Mouse left click | Select map nodes, build plots, towers, upgrades, buttons, and powers |
| `Esc` | Pause the level or close the active panel; opens options on the world map |
| `S` | Start the next wave or skip the cooldown for bonus gold when possible |
| `Q` / `W` | Decrease or increase game speed |
| `1` - `4` | Select player powers by slot |
| `E` | Close the active tower/object UI |
| `R` on world map | Open the star upgrade screen |

Some towers and heroes can use a target button to set a rally point or target position.

## Requirements

- Windows
- Visual Studio 2019 or newer, or the .NET CLI
- .NET SDK capable of building SDK-style C# projects
- .NET Core 3.1 runtime installed

The project targets `netcoreapp3.1` and uses MonoGame 3.8 packages:

- `MonoGame.Framework.WindowsDX`
- `MonoGame.Content.Builder.Task`
- `MonoGame.Framework.Content.Pipeline`
- `MonoGame.Extended`
- `MonoGame.Extended.Tiled`
- `TiledSharp`

> Note: .NET Core 3.1 is out of support. The project still targets it because the current MonoGame content builder task in this project runs `mgcb.dll` for `netcoreapp3.1`.

## Build and Run

From the repository root:

```powershell
dotnet restore TestGame.sln
dotnet build TestGame.sln
dotnet run --project TestGame/TestGame.csproj
```

You can also open `TestGame.sln` in Visual Studio and run the `TestGame` project.

If the build fails with a message saying `Microsoft.NETCore.App`, version `3.1.0`, is missing, install the .NET Core 3.1 runtime. This can happen even when a newer SDK, such as .NET 6 or .NET 8, is already installed.

## Project Layout

```text
TestGame/
  Content/      Sprites, fonts, maps, sounds, music, and Content.mgcb
  Engine/       Program entry point, Game1, and drawing/window setup
  Graphics/     Texture, sound, animation, sprite, and text loading helpers
  Huds/         Buttons, popups, tower UI, hero UI, upgrade screens, and game controls
  Levels/       Wave and path data used by each scene
  Managers/     Scene, page, wave, save, input, sound, camera, and object managers
  Objects/      Towers, monsters, projectiles, particles, soldiers, heroes, and player logic
  Pages/        Main game page, world map page, waves, paths, and object factory
  Saves/        Default save, settings, and name lists
  Scenes/       Level definitions and map-specific setup
```

## Save Data

The game reads and writes plain text save files in `TestGame/Saves`.

- `save1.txt` stores level stars, discovered monsters, unlocked towers, hero progress, active hero, unlocked heroes, and star upgrades.
- `settings.txt` stores music volume, game sound volume, and fullscreen state.
- Name lists are stored in `maleNames.txt` and `vikingNames.txt`.

