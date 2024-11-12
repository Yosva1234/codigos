using System;
using System.Collections.Generic;
using System.Text;
using Util;

namespace Redondeando
{
    class Redondeo
    {
        public static int Minredondeo(MyQuadTree q) 
        {
            int costo = 0;

            Minredondeo(q, ref costo);

            return costo;
        }

        private static void Minredondeo(MyQuadTree q, ref int costo)
        {
            if (q.Valor == ColorQuadTree.Blanco || q.Valor == ColorQuadTree.Negro)
                return;

            int blancos = 0;
            int negros = 0;

            CuentaColores(q, out blancos, out negros);

            if (negros == 4 || blancos == 4)
                return;

            else if ((negros == 3 && blancos == 1) || (blancos == 3 && negros == 1) || (negros == blancos && negros == 2))
            {
                costo++;
                return;
            }

            int blancosAux = 0;
            int negrosAux = 0;
            int costoAux = 0;
            MyQuadTree aux;

            for (int i = 0; i < q.CantHijos; i++)
            {
                CuentaColores(q[i], out blancosAux, out negrosAux);

                if (blancosAux == 3 && negrosAux == 1)
                { 
                    q = TransformaMyQuadTree(q, i, true);
                    costo++;
                }

                else if (blancosAux == 1 && negrosAux == 3)
                {
                    q = TransformaMyQuadTree(q, i, false);
                    costo++;
                }


            }
        }

        private static MyQuadTree TransformaMyQuadTree(MyQuadTree q, int i, bool aBlanco) 
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private static void CuentaColores(MyQuadTree q, out int blancos, out int negros) 
        {
            blancos = 0;
            negros = 0;

            if (q.Valor == ColorQuadTree.Blanco || q.Valor == ColorQuadTree.Negro)
                return;

            for (int i = 0; i < q.CantHijos; i++)
            {
                if (q[i].Valor == ColorQuadTree.Negro)
                    negros++;

                else if (q[i].Valor == ColorQuadTree.Blanco)
                    blancos++;
            }
        }
    }
}
