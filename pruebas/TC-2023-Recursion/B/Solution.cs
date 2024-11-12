using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace MatCom.Examen;

public class Solution
{
	public static long Solve(long capacity, long[] buy_prices, long[] buy_capacities, long[] sell_prices, long[] sell_capacities)
	{
		long maxCapacity = Math.Min(capacity, buy_capacities.Sum());

		long[] bp = (long[])buy_prices.Clone();
		Array.Sort(bp);
		long[] bc = new long[bp.Length];
		Sort(bc);

		// Sort algorithm for best sellers
		void Sort(long[] bc)
		{
			bool[] mask = new bool[bc.Length];
			for (long i = 0; i < bp.Length; i++)
			{
				for (long j = 0; j < buy_capacities.Length; j++)
				{
					if (bp[i] == buy_prices[j] && mask[j] == false)
					{
						bc[i] = buy_capacities[j];
						mask[j] = true;
						break;
					}
				}
			}
		}

		// Selling phase
		// KnapSack algorithm 	

		long Sell(long actualCapacity, long[] buy_prices, long[] buy_capacities, long[] sell_prices, long[] sell_capacities, long win, long index)
		{
			// base case
			if (index == sell_prices.Length || actualCapacity == 0)
			{
				long loss = Buy(maxCapacity, actualCapacity, bp, bc);
				long profit = win - loss;
				return profit;
			}

			// ignore this guy 
			if (actualCapacity < sell_capacities[index])
				return Sell(actualCapacity, buy_prices, buy_capacities, sell_prices, sell_capacities, win, ++index);

			long bestProfit = Math.Max
			(
				// sell
				Sell(actualCapacity - sell_capacities[index], buy_prices, buy_capacities, sell_prices, sell_capacities, win + (sell_prices[index] * sell_capacities[index]), ++index),
				// ignore
				Sell(actualCapacity, buy_prices, buy_capacities, sell_prices, sell_capacities, win, index)
			);

			return bestProfit;
		}

		// Buying phase

		static long Buy(long maxCapacity, long actualCapacity, long[] bp, long[] bc)
		{
			long loss = 0;

			// no need to refill
			if (actualCapacity == maxCapacity)
				return 0;

			long index = 0;
			long refillVendor = 0;

			// refill
			while (actualCapacity != maxCapacity)
			{
				if (bc[index] == 0)
				{
					bc[index] += refillVendor;
					index++;
					refillVendor = 0;
				}

				else
				{
					actualCapacity += 1;
					refillVendor += 1;
					bc[index] -= 1;
					loss += bp[index];
				}
			}

			// in case buying phase is over and we didn't refilled last vendor
			bc[index] += refillVendor;
			return loss;
		}

		return Sell(maxCapacity, buy_prices, buy_capacities, sell_prices, sell_capacities, 0, 0);
	}
}