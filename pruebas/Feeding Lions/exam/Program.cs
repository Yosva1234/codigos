using System.ComponentModel;
public static class Solution
{
    static int GetRoutes(Map map, int n)
    {
        // Elimine la siguiente línea y ponga aquí su código
        n = map.N < n ? map.N : n;
        var result = GetRoute(map, new bool[map.N], n, 0, 0, 0, int.MaxValue);
        return result;
    }

    static int GetRoute(Map map, bool[] visited, int worker, int time, int totalTime, int actualPos, int bestTime)
    {
        if (worker == 0) return visited.All(x => x == true) ? totalTime : bestTime;

        for (int i = 0; i < map.N; i++)
        {
            if (map.IsOnTime(i, time + map[actualPos, i]) && !visited[i] && time + map[actualPos, i] < bestTime)
            {
                visited[i] = true;
                bestTime = Math.Min(bestTime, GetRoute(map, visited, worker, time + map[actualPos, i], totalTime + map[actualPos, i], i, bestTime));
                visited[i] = false;
            }
        }

        return GetRoute(map, visited, worker - 1, 0, totalTime + map[actualPos, 0], 0, bestTime);
    }
}


var matrix = new int[,]
{
    {0,1,5,69,44,47,74,23,59},
    {1,0,78,52,54,47,78,86,34},
    {5,78,0,43,9,9,37,16,65 },
    {69,52,43,0,50,90,8,3,93},
    {44,54,9,50,0,2,22,57,82},
    {47,47,9,90,2,0,1,31,69},
    {74,78,37,8,22,1,0,74,87},
    {23,86,16,3,57,31,74,0,30},
    {59,34,65,93,82,69,87,30,0}
};

var start = new int[] { 0, 38, 82, 30, 34, 40, 51, 52, 99 };
var end = new int[] { 0, 108, 134, 116, 64, 125, 113, 113, 149 };
var map = new Map(matrix, start, end);

Console.WriteLine(GetRoutes(map, 16));