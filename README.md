# BetterFog

Other mods remove fog, Mistlands mist and fire smoke entirely. BetterFog just tones them down, so the game keeps its atmosphere and is much nicer to play.

Screenshots are in [SCREENSHOTS.md](https://github.com/JevMods/BetterFog/blob/main/SCREENSHOTS.md).

## Features

- Reduces the density of the distance fog in every biome and weather.
- Reduces the opacity of the Mistlands mist, the fog banks and the weather fog.
- Reduces the opacity of fire smoke.
- Each reduction has its own setting, from none to vanilla.

## Configuration

The settings are in `BepInEx/config/JevMods.BetterFog.cfg`, created on first launch. Each value goes from 0 to 1, where 1 is vanilla.

- `Fog.Density`: reduces the distance fog density to this fraction of vanilla (default 0.5).
- `Fog.MistOpacity`: reduces the opacity of the mist and fog particles to this fraction of vanilla. Restart the game after changing it (default 0.2).
- `Smoke.Opacity`: reduces the opacity of fire smoke to this fraction of vanilla (default 0.5).

## Feedback

Found a bug or have an idea for a change? Open an issue on the [GitHub issues page](https://github.com/JevMods/BetterFog/issues). Refactoring suggestions are welcome too. I'll go through everything as fast as I can.

## Building from source

To build you need Windows, the .NET SDK 8 or newer (with the .NET Framework 4.8 developer pack), Valheim and BepInEx. The easiest way to get BepInEx is to install BepInExPack_Valheim in a Thunderstore Mod Manager profile.

```
git clone https://github.com/JevMods/BetterFog.git
cd BetterFog
dotnet build src/BetterFog -c Release
```

Then copy `src/BetterFog/bin/Release/BetterFog.dll` into `BepInEx/plugins`.

The build looks for Valheim through Steam and for BepInEx in the Default profile of the Thunderstore Mod Manager. If yours live elsewhere, pass the paths:

```
dotnet build src/BetterFog -c Release -p:ValheimDir="D:\Games\Valheim" -p:BepInExDir="D:\Games\Valheim\BepInEx"
```

You can also set the `VALHEIM_INSTALL` environment variable. With no Valheim install at all, point `ManagedDir` at the `valheim_server_Data/Managed` folder of the free Valheim Dedicated Server (Steam app 896660). The GitHub workflow does exactly that.

## Notes

- Client-side: only the player who wants the effect needs to install it.
- Source: https://github.com/JevMods/BetterFog
