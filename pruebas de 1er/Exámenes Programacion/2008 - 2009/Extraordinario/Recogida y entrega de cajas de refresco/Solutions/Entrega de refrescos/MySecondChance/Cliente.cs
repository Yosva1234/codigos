using System;
using System.Collections.Generic;
using System.Text;

namespace MySecondChance
{
    public class Cliente 
    {
        int cantCajasBotellasLLenas;
        int cantCajasBotellasVacias;

        public Cliente(int CantCajasBotellasLLenas, int CantCajasBotellasVacias) 
        {
            this.cantCajasBotellasLLenas = CantCajasBotellasLLenas;
            this.cantCajasBotellasVacias = CantCajasBotellasVacias;
        }

        public virtual int CantCajasBotellasLLenas 
        {
            get { return cantCajasBotellasLLenas; }
        }
        
        public virtual int CantCajasBotellasVacias 
        {
            get { return cantCajasBotellasVacias; }
        }
    }
}
