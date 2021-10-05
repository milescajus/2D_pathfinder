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
        /*
        for (int i = 0; i < grid.GetLength(0); i++) {
            for (int j = 0; i < grid.GetLength(1); i++) {
                origin = new int[] {4, 5};
                Move(new int[] {i, j});
                PrintGrid();
            }
        }
        */

        int[] dest = new int[] {1, 1};
        Move(dest);
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
        Console.WriteLine();
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
        int[] best_nb = origin;

        while (m_points > 0) {
		    foreach (int[] nb in FindNeighbors()) {
			    if (grid[nb[1], nb[0]]) { // free neighbor exists
                    double cur_dist = Math.Pow(dest[0] - nb[0], 2) + Math.Pow(dest[1] - nb[1], 2);
                    double best_dist = Math.Pow(dest[0] - best_nb[0], 2) + Math.Pow(dest[1] - best_nb[1], 2);
				    if (cur_dist < best_dist) { // squared distance of neighbor is less than current position
                        best_nb = nb;
					    break;
			        } else { continue; } // look for better neighbors
                }
		    }
			origin = best_nb;
			m_points--;
            Console.WriteLine("Remaining moves: " + m_points);
            PrintGrid();
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
