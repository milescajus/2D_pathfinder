// D* (DumbStar or Dumpster) Algorithm
// by MilesCajus
//
// (c) 2021

using System;
using System.IO;
using System.Collections.Generic;

class Pathfinder
{
    static int width;
    static int height;
    static bool[,] grid;
    static int[] origin;
    static int m_points;
    static float[] n_avgs;
    static float[] a_avgs;

    public static void Main(string[] args) {
        n_avgs = new float[1000];
        a_avgs = new float[1000];
        
        for (int i = 0; i < n_avgs.Length; i++) {
            (float, float) t = GetAvgs(args.Length != 0 ? Int32.Parse(args[0]) : 0);
            n_avgs[i] = t.Item1;
            a_avgs[i] = t.Item2;
        }

        using var writer = new StreamWriter("stats.csv");

        writer.WriteLine("Norm,Alt");

        for (int i = 0; i < n_avgs.Length; i++) {
            writer.WriteLine(n_avgs[i] + "," + a_avgs[i]);
        }
    }

    public static (float, float) GetAvgs(int print) {
        int[] norm = new int[100];
        int[] alt = new int[100];
        float n_avg = 0;
        float a_avg = 0;

        for (int i = 0; i < norm.Length ; i++) {
            m_points = 12; // Int32.Parse(args[0]);
            RunSim(false, print);
            norm[i] = m_points;
        }

        for (int i = 0; i < alt.Length ; i++) {
            m_points = 12; // Int32.Parse(args[0]);
            RunSim(true, print);
            alt[i] = m_points;
        }

        foreach (int n in norm){
            n_avg += n;
        }

        n_avg /= norm.Length;

        foreach (int n in alt){
            a_avg += n;
        }

        a_avg /= alt.Length;

        return (n_avg, a_avg);
    }

    public static void RunSim(bool alt, int print=0) {
        width = 10;
        height = 12;
        grid = new bool[height, width];
        origin = new int[] {4, 5};

        int[,] blocked = {{2, 2}, {5, 2}, {6, 2},
            {2, 3}, {6, 3},
            {2, 4},
            {6, 5},
            {2, 6}, {3, 6}, {4, 6}, {5, 6}, {6, 6}, {7, 6},
            {2, 8},
            {2, 9}, {3, 9}, {4, 9}, {5, 9}, {6, 9}, {7, 9}};

        if (print > 0) Console.WriteLine("Initializing Grid...");
        InitGrid(blocked);
        if (print > 0) Console.WriteLine("Initial state:");
        if (print > 0) PrintGrid();
        if (print > 0) Console.WriteLine();
        /*
           for (int i = 0; i < grid.GetLength(0); i++) {
           for (int j = 0; i < grid.GetLength(1); i++) {
           origin = new int[] {4, 5};
           Move(new int[] {i, j});
           }
           }
           */

        int[] dest = new int[] {4, 7};
        if (!alt) { Move(dest, print > 1 ? true : false); }
        else { Move_alt(dest, print > 1 ? true : false); }

        if (print > 0) PrintGrid();
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

    public static void Move(int[] dest, bool print=false) {
        var past_moves = new HashSet<(int, int)>();

        while (m_points > 0 && !(origin[0] == dest[0] && origin[1] == dest[1])) {
            // has movement points and not at destination
            var nbs = new Dictionary<double, int[]>();
            var dists = new List<double>();

            foreach (int[] nb in FindNeighbors()) {
                if (grid[nb[1], nb[0]] && !(past_moves.Contains((nb[0], nb[1])))) {
                    // free neighbor exists and has not been moved to before

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

            dists.Sort();                           // O(n log n)

            past_moves.Add((origin[0], origin[1])); // add current location to past_moves
            origin = nbs[dists[0]];                 // move to neighbor closest to destination
            m_points--;

            if (print) {
                PrintGrid();
                Console.WriteLine("Remaining moves: " + m_points + "\n");
            }
        }
    }

    public static void Move_alt(int[] dest, bool print=false) {
        while (m_points > 0 && !(origin[0] == dest[0] && origin[1] == dest[1])) {
            // has movement points and not at destination
            double best = -1.0;

            foreach (int[] nb in FindNeighbors()) {

                if (grid[nb[1], nb[0]]) { // free neighbor exists
                    double distance = Math.Pow(dest[0] - nb[0], 2) + Math.Pow(dest[1] - nb[1], 2);

                    if (best == -1.0 || distance < best) {
                        // no distance found yet or current distance is better than the best
                        best = distance;
                        grid[origin[1], origin[0]] = false; // block previous path
                        origin[0] = nb[0];
                        origin[1] = nb[1];
                    } else if (best == distance) {
                        // if move already exists with same distance, flip a coin to choose
                        var rnd = new Random();
                        if (rnd.Next(2) == 0) {
                            best = distance;
                            grid[origin[1], origin[0]] = false; // block previous path
                            origin[0] = nb[0];
                            origin[1] = nb[1];
                        }
                    }
                }
            }

            // TODO: find alternative to creating walls for preventing getting caught in a loop
            m_points--;

            if (print) {
                PrintGrid();
                Console.WriteLine("Remaining moves: " + m_points + "\n");
            }
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
