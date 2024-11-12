
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;


//     # region Permutation Algorithm

//     class Permutations
//     {
//         public static void Main()
//         {
//             List<int> permutation = new List<int>();
//             int[] set = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//             bool[] mask = new bool[set.Length];

//             Stopwatch crono = new Stopwatch();
//             crono.Start();

//             /* Permutations */

//             void Permute(int[] set)
//             {
//                 if (permutation.Count == set.Length)
//                     Printer.PrintSet(permutation);

//                 for (int i = 0; i < set.Length; i++)
//                 {
//                     if (!mask[i])
//                     {
//                         mask[i] = true;
//                         permutation.Add(set[i]);
//                         Permute(set);
//                         permutation.Remove(permutation.Last());
//                         mask[i] = false;
//                     }
//                 }
//             }

//             Permute(set);
//             crono.Stop();
//             System.Console.WriteLine(crono.Elapsed);
//         }
//     }

//     #endregion

//     #region Variation Algorithm

//     class Variations
//     {
//         public static void Main()
//         {
//             List<int> variation = new List<int>();
//             int[] set = { 1, 2, 3, 4, 5, 6 };
//             bool[] mask = new bool[set.Length];

//             /* Variations */
//             void Variate(int[] set, int cap)
//             {
//                 if (variation.Count == cap)
//                     Printer.PrintSet(variation);

//                 for (int i = 0; i < set.Length; i++)
//                 {
//                     if (!mask[i])
//                     {
//                         mask[i] = true;
//                         variation.Add(set[i]);
//                         Variate(set, cap);
//                         variation.Remove(variation.Last());
//                         mask[i] = false;
//                     }
//                 }
//             }

//             Variate(set, 3);
//         }
//     }
//     #endregion

//     #region Repetitive Variation
//     class RepetitiveVariation
//     {
//         static void Main()
//         {
//             List<int> variation = new List<int>();
//             int[] set = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//             /* Repetitive Variation */
//             void Variate(int[] set, int cap)
//             {
//                 if (variation.Count == cap)
//                 {
//                     Printer.PrintSet(variation);
//                     return;
//                 }

//                 for (int i = 0; i < set.Length; i++)
//                 {
//                     variation.Add(set[i]);
//                     Variate(set, cap);
//                     variation.Remove(set[i]);
//                 }
//             }

//             Variate(set, 10);
//         }
//     }
//     #endregion

    #region Combination
    public class Combination
    {
        static void Main()
        {
            List<int> combination = new List<int>();
            int[] set = { 1, 2, 3, 4, 5 };

            void Combine(int[] set, int cap, int index)
            {
                if (combination.Count == cap)
                {
                    Printer.PrintSet(combination);
                    return;
                }

                if (index == set.Length)
                {
                    return;
                }

                combination.Add(set[index]);
                Combine(set, cap, index + 1);
                combination.Remove(combination.Last());
                Combine(set, cap, index + 1);
            }

            Combine(set, 5, 0);
        }
    }
    #endregion

//     #region Decompose
//     public class Decompose
//     {
//         static void Main()
//         {
//             int n = 4;
//             List<int> sumandos = new List<int>();

//             void Decompose(int n)
//             {
//                 if (n == 0)
//                 {
//                     Printer.PrintSet(sumandos);
//                     return;
//                 }
//                 for (int i = 1; i <= n; i++)
//                 {
//                     sumandos.Add(i);
//                     Decompose(n - i);
//                     sumandos.Remove(i);
//                 }
//             }

//             Decompose(3);
//         }

//     }

//     #endregion

#region KnapSack01
class KnapSack01
{
    static void Main()
    {
        int best = 0;

        void KnapSack(int[] profits, int[] weights, int capacity, int actualProfit, int index)
        {
            if (index == profits.Length || capacity == 0)
            {
                best = actualProfit > best ? actualProfit : best;
                return;
            }

            // 0
            KnapSack(profits, weights, capacity, actualProfit, index + 1);

            // 1
            if (weights[index] <= capacity)
                KnapSack(profits, weights, capacity - weights[index], actualProfit + profits[index], index + 1);

        }

        int[] profits = { 10, 40, 30, 20 };
        int[] weights = { 4, 3, 5, 2 };
        int capacity = 8;

        KnapSack(profits, weights, capacity, 0, 0);
        System.Console.WriteLine(best);
    }
}

#endregion
public class Printer
{
    public static void PrintSet<T>(IEnumerable<T> set) => System.Console.WriteLine(string.Join(',', set));
}

