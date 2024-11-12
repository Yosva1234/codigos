namespace MatCom.Examen;

public static class Solution
{
    public static double MinDanger(CityNode RootCity)
    {
        // we already are in a leaf node
        if (RootCity.Roads().Length == 0) return 0;
        return GetMinDanger(RootCity, 1, 0, int.MaxValue, false);
    }

    static double GetMinDanger(CityNode actualCity, int traversedCities, double actualDanger, double minDanger, bool arrivedByRoad)
    {
        // cut
        if (actualDanger >= minDanger)
        {
            return actualDanger;
        }

        // Base case:
        // we reached a leaf node and we can take the ship
        if (actualCity.Roads().Length == 0 && !actualCity.HasTeleport().Item1)
        {
            // System.Console.WriteLine(actualDanger);
            return actualDanger;
        }

        // if we arrive by road to a city and it has TP we must use it 
        if (arrivedByRoad && actualCity.HasTeleport().Item1)
        {
            return minDanger = Math.Min(minDanger, GetMinDanger(actualCity.HasTeleport().Item2, traversedCities + 1, actualDanger, minDanger, false));
        }

        // otherwise we must take the roads
        foreach (var road in actualCity.Roads())
        {
            minDanger = Math.Min(minDanger, GetMinDanger(road.Item2, traversedCities + 1, actualDanger + (traversedCities * road.Item1), minDanger, true));
        }

        return minDanger;
    }
}