using System;
using System.Collections.Generic;

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
        m_points = Int32.Parse(args[0]);
        origin = new int[] {4, 5};
        
        
        int[,] blocked = {{2, 2}, {5, 2}, {6, 2},
                          {2, 3}, {6, 3},
                          {2, 4},
                          {6, 5},
                          {2, 6}, {3, 6}, {4, 6}, {5, 6}, {6, 6}, {7, 6},
                          {2, 8},
                          {2, 9}, {3, 9}, {4, 9}, {5, 9}, {6, 9}, {7, 9}};
                          
        InitGrid(blocked);
        Console.WriteLine("Initial state:");
        PrintGrid();
        Console.WriteLine();
        /*
        for (int i = 0; i < grid.GetLength(0); i++) {
            for (int j = 0; i < grid.GetLength(1); i++) {
                origin = new int[] {4, 5};
                Move(new int[] {i, j});
            }
        }
        */

        int[] dest = new int[] {4, 7};
        Move(dest);
    }
    
    public static void PrintGrid() {
        for (int i = 0; i < grid.GetLength(0); i++) {
            for (int j = 0; j < grid.GetLength(1); j++) {
                if (i == origin[1] && j == origin[0] /*i == 5 && j == 4*/) {
                    Console.Write("[X]");
                } else {
                    Console.Write(grid[i, j] ? "[ ]" : "[*]");
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
        while (m_points > 0 && !(origin[0] == dest[0] && origin[1] == dest[1])) {
            // has movement points and not at destination
            var nbs = new Dictionary<double, int[]>();
            var dists = new List<double>();

            foreach (int[] nb in FindNeighbors()) {

                if (grid[nb[1], nb[0]]) { // free neighbor exists
                    double distance = Math.Pow(dest[0] - nb[0], 2) + Math.Pow(dest[1] - nb[1], 2);

                    if (nbs.ContainsKey(distance)) {
                        // if move already exists with same distance, flip a coin to choose
                        var rnd = new Random();
                        nbs[distance] = rnd.Next(2) == 0 ? nbs[distance] : nb;
                    } else {
                        nbs.Add(distance, nb);
                    }
                }
            }

            // Sort neighbor distances
            foreach (double d in nbs.Keys) {
                dists.Add(d);
            }

            dists.Sort();

            // TODO: find alternative to creating walls for preventing getting caught in a loop
            grid[origin[1], origin[0]] = false; // block previous path
            origin = nbs[dists[0]];             // move to neighbor closest to destination
            m_points--;

            PrintGrid();
            Console.WriteLine("Remaining moves: " + m_points + "\n");
        }
    }
    
    public static int[][] FindNeighbors() {
        int[] north = new int[] {origin[0], origin[1] - 1};
        int[] south = new int[] {origin[0], origin[1] + 1};
        int[] east = new int[] {origin[0] + 1, origin[1]};
        int[] west = new int[] {origin[0] - 1, origin[1]};
        
        return new int[][] {north, south, east, west};
    }
}
