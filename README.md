# Game-of-Life #
Implementation of [Game of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life) in C# (VS2015) and XNA 4.0.

![Game of Life rule preview](https://user-images.githubusercontent.com/2995236/28494033-01ffa268-6f23-11e7-90d2-5477567fe3bd.png)

## Configuration ##
[app.config](https://github.com/Sajgoniarz/Game-of-Life/blob/master/Game%20Of%20Life/Game_Of_Life/app.config) contains few useful settings for playing around with automata :
* **WindowWidth** - Application window width
* **WindowHeight** - Application window height
* **Fullscreen** - Flag to display window in fullscreen mode
* **WallpaperMode** - Flag to display as Wallpaper - Experimental "Works for me". (To close it, you need to kill process)
* **PixelSize** - Multiplication ratio for a pixel, useful for more detailed projection without messing with window settings
* **Density** - Describes how many % of cells should be alive in first generation
* **TickTime** - Time in ms between spawning next generation
* **Survivors** - Cells which will survive to next generation (S)
* **Reproductors** - Death cells which will become alive in next generation (B)

## Applying Rules ##
Rules Format in [app.config](https://github.com/Sajgoniarz/Game-of-Life/blob/master/Game%20Of%20Life/Game_Of_Life/app.config) can not be straightforward as you can find them in the web so..

**B45678/S2345** (fav one btw.)

will be...

```xml
<add key="Survivors" value="2345" />
<add key="Reproductors" value="45678" />
```

... and will looks like ...

![Rule B45678/S2345 preview](https://user-images.githubusercontent.com/2995236/28494037-059677e4-6f23-11e7-8798-685e750498c9.png)

Few rules can be found on [wiki](https://en.wikipedia.org/wiki/Life-like_cellular_automaton) if you don't like them, you can try one from 2<sup>18</sup> another rules :)

**ENJOY!**

