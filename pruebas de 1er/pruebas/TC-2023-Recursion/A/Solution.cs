namespace MatCom.Examen;

public class Solution
{
	public static long Solve(long capacity, long[] buy_prices, long[] buy_capacities, long[] sell_prices, long[] sell_capacities)
	{
		// filter
		long sum = sell_capacities.Where(x => x <= capacity).Sum();
		long maxCapacity = capacity > sum ? sum : capacity;
		long actualCapacity = 0;

		var bp = new (long, long)[buy_prices.Length];
		var sp = new (long, long)[sell_capacities.Length];

		for (int i = 0; i < bp.Length; i++)
			bp[i] = (buy_prices[i], buy_capacities[i]);

		for (int i = 0; i < sp.Length; i++)
			sp[i] = (sell_prices[i], sell_capacities[i]);

		bp = bp.OrderBy(x => x.Item1).ToArray();
		sp = sp.OrderBy(x => x.Item1).ToArray();


		// Delete this line and code here:
		var tup = Buy(actualCapacity, maxCapacity, bp);
		return Sell(tup.Item2, sp, 0, tup.Item1, 0);
	}

	static (long, long) Buy(long actualCapacity, long maxCapacity, (long, long)[] bp)
	{
		if (actualCapacity == maxCapacity) { return (0,actualCapacity); }

		long loss = 0;
		long index = 0;

		while (actualCapacity != maxCapacity)
		{
			if (bp[index].Item2 == 0)
			{
				index++;
			}
			else
			{
				actualCapacity += 1;
				bp[index].Item2 -= 1;
				loss += bp[index].Item1;
			}
		}

		return (loss, actualCapacity);
	}

	static long Sell(long actualCapacity, (long, long)[] sp, long win, long loss, long index)
	{
		if (index == sp.Length || actualCapacity == 0)
		{
			long profit = win - loss;
			return profit;
		}

		if (sp[index].Item2 > actualCapacity) { return Sell(actualCapacity, sp, win, loss, ++index); }

		long bestProfit = Math.Max
		(
			Sell(actualCapacity - sp[index].Item2, sp, win + (sp[index].Item1 * sp[index].Item2), loss, ++index),
			Sell(actualCapacity, sp, win, loss, index)
		);

		return bestProfit;
	}
}
