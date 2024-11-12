using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatCom.Examen;

public class NavesEspaciales
{

    public static int max;
    public static int MaximoRescate(bool[,] campoBatalla)
    {
        
           max = 0;

           for(int x = 0; x<campoBatalla.GetLength(1); x++)
           for(int y = 0; y<campoBatalla.GetLength(0); y++)
           if(campoBatalla[y,x])
           {
                campoBatalla[y,x] = false;
                cc(x,y,campoBatalla,0);
           }

           return max;

    }

  static void cc(int x, int y, bool[,] campoaux,  int cnaves)
  {
    max = Math.Max(cnaves,max);
     bool [,] campo = new bool[campoaux.GetLength(0),campoaux.GetLength(1)];

     for (int i = 0; i < campoaux.GetLength(1); i++) for(int j = 0; j<campoaux.GetLength(0); j++) campo[j,i] = campoaux[j,i];

    int [] arrayfila = {0,0,1,-1};
    int [] arraycolu = {1,-1,0,0};

    for(int i = 0; i<4; i++)
    {
        for(int q = 1; ;q++)
        {
          int fq = y+(arrayfila[i]*q);
          int cq = x+(arraycolu[i]*q);
          if(fq<0 || cq<0 || fq>=campo.GetLength(0) || cq>=campo.GetLength(1)) break;

           if(campo[fq,cq])
           {
              campo[fq,cq] = false;

              for(int nq = q+1; ; nq++)
              {
              int nfq = y+(arrayfila[i]*nq);
              int ncq = x+(arraycolu[i]*nq);
             if(nfq<0 || ncq<0 || nfq>=campo.GetLength(0) || ncq>=campo.GetLength(1)|| campo[nfq,ncq]) break;
             cc(ncq,nfq,campo,cnaves+1);
              }
              campo[fq,cq] = true;
              break;
           }
        }
    }
  }

}
