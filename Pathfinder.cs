using System;

class Pathfinder
{
	static int width;
	static int height;
	static bool[,] grid;
	static int[] origin;
	static int m_points;
	
	public static void Main(string[] args) {
		width = 10;
		height = 12;
		grid = new bool[height, width];
		m_points = 6;
		origin = new int[] {4, 5};
		
		
		int[,] blocked = {{2, 2}, {5, 2}, {6, 2},
						  {2, 3}, {6, 3},
						  {2, 4},
						  {6, 5},
						  {2, 6}, {3, 6}, {4, 6}, {5, 6}, {6, 6}, {7, 6},
						  {2, 8},
						  {2, 9}, {3, 9}, {4, 9}, {5, 9}, {6, 9}, {7, 9}};
						  
		InitGrid(blocked);
		PrintGrid();
        for (int i = 0; i < grid.GetLength(0); i++) {
            for (int j = 0; i < grid.GetLength(1); i++) {
                origin = new int[] {4, 5};
                Move(new int[] {i, j});
                PrintGrid();
            }
        }
	}
	
	public static void PrintGrid() {
		for (int i = 0; i < grid.GetLength(0); i++) {
			for (int j = 0; j < grid.GetLength(1); j++) {
				if (i == origin[1] && j == origin[0] /*i == 5 && j == 4*/) {
					Console.Write("[X]");
				} else {
					Console.Write(grid[i, j] ? "[ ]" : "[-]");
				}
			}
			Console.WriteLine();
		}
	}
	
	public static void InitGrid(int[,] blocked) {
		for (int i = 0; i < grid.GetLength(0); i++) {
			for (int j = 0; j < grid.GetLength(1); j++) {
				grid[i, j] = true;
			}
		}
		
		for (int i = 0; i < blocked.GetLength(0); i++) {
			grid[blocked[i, 1], blocked[i, 0]] = false;
		}
	}
	
	public static void Move(int[] dest) {
        while (m_points > 0) { // FIXME: INFINITE LOOP
		    foreach (int[] nb in FindNeighbors()) {
			    if (grid[nb[1], nb[0]]) {
				    // free neighbor exists
				    if (nb[0] == dest[0] || nb[1] == dest[1]) {
					    // neighbor aligns with destination
					    origin = nb;
					    m_points--;
					    return;
                    } else {
                        // move in either x or y direction
                        // depending on which ordinate is closer to destination equivalent
                    }
			    } else {
				    Console.WriteLine("NO MOVES");
                    return;
			    }
		    }
        }
	}
	
	public static int[][] FindNeighbors() {
		int[] north = new int[] {origin[1] - 1, origin[0]};
		int[] south = new int[] {origin[1] + 1, origin[0]};
		int[] east = new int[] {origin[1], origin[0] + 1};
		int[] west = new int[] {origin[1], origin[0] - 1};
		
		
		
		return new int[][] {north, south, east, west};
	}
}
