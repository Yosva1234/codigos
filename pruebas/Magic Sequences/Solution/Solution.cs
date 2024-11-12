using System.Diagnostics;
using System.Dynamic;

namespace Solution;

public static class Solution
{
    public static int CantidadMinimaEliminaciones(int[] secuencia)
    {
        // /* new code */
        bool[] mask = new bool[secuencia.Length];
        if (secuencia.Length == 0 || IsMagic(secuencia))
        {
            return 0;
        }

        bool IsMagic(int[] secuencia)
        {
            for (int i = 0; i < secuencia.Length; i++)
            {
                if (mask[i])
                {
                    int length = secuencia[i];
                    int howMany = 0;
                    for (int j = i + 1; j < secuencia.Length; j++)
                    {
                        if (mask[i])
                        {
                            howMany++;
                        }

                        if (howMany == length)
                            break;

                        if (secuencia.Length - length <= 0)
                            return false;
                    }

                    if (howMany == length)
                    {
                        i = i + length + 1;
                    }
                }
            }

            return true;
        }

        int actualElim = 0;

        void Combine(int cap)
        {
            for (int i = 0; i < secuencia.Length; i++)
            {
                if (!mask[i])
                {
                    mask[i] = true;
                    cap--;

                    if (cap == 0)
                        IsMagic();

                    Combine();
                    mask[i] = false;
                }

            }
        }

    }
}
