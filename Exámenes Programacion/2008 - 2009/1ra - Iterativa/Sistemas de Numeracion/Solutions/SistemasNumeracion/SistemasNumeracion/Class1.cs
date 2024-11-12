using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasNumeracion
{
    public class Examen
    {
        public static int ParseInt(string numero, char[] digitosBase)
        {
            int res = 0;
            int dif = 0;
            foreach (char i in numero)
            {
                res += (int)IndexOf(digitosBase, i) * (int)Math.Pow(digitosBase.Length, numero.Length-dif-1);
                dif++;
            }
            return res;
        }
        //
        //***Metodo auxiliar***
        //
        private static int IndexOf(char[] numeros, char c)
        {
            int res = -1;
            for (int i = 0; i < numeros.Length; i++)
                if (numeros[i] == c)
                    res = i;
            return res;
        }
    }
}
