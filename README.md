# C# 2D Pathfinder

C# class for a 2D grid-based pathfinder algorithm.

Compile and run with movement points as a command-line argument, e.g.:

`Pathfinder.exe 6`

Walls must be edited manually in `Pathfinder.cs`.

Currently simply prints the grid in the terminal with each move.

Example Output
---
`> Pathfinder.exe 10` where target is `[4, 7]`

```
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

(3, 5) -- 5
(4, 4) -- 9
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][X][*][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 9

(2, 5) -- 8
(3, 4) -- 10
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][X][*][*][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 8

(1, 5) -- 13
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][X][*][*][*][ ][*][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 7

(1, 6) -- 10
(1, 4) -- 18
(0, 5) -- 20
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][*][*][*][*][ ][*][ ][ ][ ]
[ ][X][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 6

(1, 7) -- 9
(0, 6) -- 17
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][*][*][*][*][ ][*][ ][ ][ ]
[ ][*][*][*][*][*][*][*][ ][ ]
[ ][X][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 5

(2, 7) -- 4
(1, 8) -- 10
(0, 7) -- 16
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][*][*][*][*][ ][*][ ][ ][ ]
[ ][*][*][*][*][*][*][*][ ][ ]
[ ][*][X][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 4

(3, 7) -- 1
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][*][*][*][*][ ][*][ ][ ][ ]
[ ][*][*][*][*][*][*][*][ ][ ]
[ ][*][*][X][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 3

(4, 7) -- 0
(3, 8) -- 2
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][*][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][*][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][*][*][*][*][ ][*][ ][ ][ ]
[ ][*][*][*][*][*][*][*][ ][ ]
[ ][*][*][*][X][ ][ ][ ][ ][ ]
[ ][ ][*][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][*][*][*][*][*][*][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
Remaining moves: 2
```
