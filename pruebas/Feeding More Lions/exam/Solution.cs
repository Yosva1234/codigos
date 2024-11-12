public static class Solution
{
    public static int Solve(Map map, int[] capacities)
    {
        return Solve(map, capacities, new bool[map.M], 0, 0, 0, 0, int.MaxValue);
    }

    static int Solve(Map map, int[] capacities, bool[] visited, int actualPosition, int actualKart, int actualTime, int totalTime, int bestTime)
    {
        if (actualKart == capacities.Length)
        {
            var allLionsWereVisited = visited.All(x => x == true);
            return allLionsWereVisited ? totalTime : bestTime;
        }

        for (int i = 0; i < map.M; i++)
        {
            if (!visited[i] && map.Demand[i] <= capacities[actualKart] && map[actualPosition, i] + actualTime < bestTime)
            {
                visited[i] = true;
                capacities[actualKart] -= map.Demand[i];
                bestTime = Math.Min(bestTime, Solve(map, capacities, visited, i, actualKart, actualTime + map[actualPosition, i], totalTime + map[actualPosition, i], bestTime));
                capacities[actualKart] += map.Demand[i];
                visited[i] = false;
            }
        }

        return Solve(map, capacities, visited, 0, actualKart + 1, 0, totalTime + map[actualPosition, 0], bestTime);
    }

}
