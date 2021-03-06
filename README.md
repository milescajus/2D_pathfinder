# C# 2D Pathfinder

C# class for a 2D grid-based pathfinder algorithm, lovingly named D\*, DumbStar, or Dumpster.

Compile and run with printing as a command-line argument, e.g.:

`Pathfinder.exe 1` to print, otherwise `Pathfinder.exe` will run without terminal printing and simply output a `stats.csv` file with the results of the average movement points remaining for the example currently set up in the code.

UNIX systems should use `csc` for compilation and `mono` to run the executable.

Walls must be edited manually in `Pathfinder.cs`.

Currently simply prints the grid in the terminal with each move, where `[ ]` is a free space, `[X]` is the current position, and `[*]` is a wall. Past moves are tracked and avoided to prevent getting stuck in loops.

Changelog
---
- added CSV output to record the average number of movement points remaining for the alternate movement methods
- added `m_points` comparison to see if `Move()` reaches the target with fewer moves on average than `Move_alt()` (higher number means more moves remaining, i.e. fewer moves used to reach target)
- now tracking past moves with a `HashSet` to prevent looping, rather than placing a wall at previous location
- added `Move_alt()` for runtime analysis

TODO
---
- switch to using Tuples for all coordinates
- create graphical representation based on Godot's A\* demo

## Runtime Comparison

There are two methods for finding the optimal path to the target position, `Move()` and `Move_alt()`. The former uses a dictionary to store all possible moves and sorts the keys to determine the best move, and the latter simply stores the best distance as a `double` and compares with each free neighbor. The intention is to perform a runtime analysis to see which approach is more efficient and effective.

Example Output
---
`> Pathfinder.exe 1` where target is `[4, 7]`

```
Initializing Grid...
Initial state:
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][X][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]

[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][X][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 11

[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][X][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 10

[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][X][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 9

[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][X][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 8

[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][X][ ][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 7

[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][X][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 6

[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][X][ ][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 5

[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][*][ ][ ][ ]
[ ][X][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 4

[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][X][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 3

[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][X][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 2

[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][X][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 1

[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][X][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 0
```
