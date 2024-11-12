using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weboo.PrimerExamen
{
    public class Juego
    {
        public static int PosicionFinal(int[] array, int[] tiradas)
        {   int size=array.Length;
            int size2 = tiradas.Length; 
           
            int pos_array = 0;
            int num_tiradas = 1;
            int pos_final=pos_array;
            int dado = 0;
               for (int j = 1; j < size2; j++)
                {   
                     dado =tiradas[j] ;
                     num_tiradas--;
                   if(num_tiradas==0)
                        break;
                for (int i = 0; i <= size - 1; i++)
                {
                    if ((array[i] < 0) || (array[i] > 0))
                        pos_array += dado + array[i];
                    else if (array[i] == 0)
                        pos_array += dado;
                    else if (array[i] > size)
                        pos_array = 0;
                    else if (array[i] < i)
                        pos_array = -1;
                       }
                        
                }
               
           
            return pos_final;
          
            
            }

           
        }
    }

        
              
                       
                      
  
           