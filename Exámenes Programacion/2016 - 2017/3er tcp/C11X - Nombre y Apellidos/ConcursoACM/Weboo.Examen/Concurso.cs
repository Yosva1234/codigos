using System;
using System.Collections.Generic;
using System.Linq;
using Weboo.Examen.Interfaces;

namespace Weboo.Examen
{
    

    public class Equipo
    {
        internal List<int>[] envios;
        internal bool[] resueltos;
        int penalizacion;
        public int Number { get; }
        public int? Descalificado { get; private set; }

        public Equipo(int m, int p, int number)
        {
            envios = new List<int>[m];
            for (int i = 0; i < m; i++)
            {
                envios[i] = new List<int>();
            }
            resueltos = new bool[m];
            penalizacion = p;
            this.Number = number;
        }

        public void Descalificar(int time)
        {
            if (Descalificado == null)
                Descalificado = time;
        }

        public int GetPenalty(int time)
        {
            int suma = 0;
            for (int i = 0; i < envios.Length; i++)
            {
                if (resueltos[i] && envios[i][envios[i].Count - 1] <= time)
                {
                    foreach (var item in envios[i])
                    {
                        suma += item;
                    }
                    suma += (envios.Count() - 1) * penalizacion;
                }
            }
            return suma;
        }

        public int CantResueltos(int time)
        {
            int total = 0;
            for (int i = 0; i < resueltos.Length; i++)
            {
                if (resueltos[i] && envios[i][envios[i].Count - 1] <= time)
                    total += 1;
            }
            return total;
        }

        public void MandarSolucion(int tiempo, int m, bool solved)
        {
            if (resueltos[m - 1])
                return;
            if (solved)
                resueltos[m - 1] = true;
            envios[m - 1].Add(tiempo);
        }
    }

    public class Concurso : IConcurso
    {
        List<Equipo> equipos = new List<Equipo>();
        int m;
        int penalizacion;

        public Concurso(int equipos, int problemas, int penalizacion)
        {
            m = problemas;
            for (int i = 0; i < equipos; i++)
            {
                this.equipos.Add(new Equipo(problemas, penalizacion,i + 1));
            }
            this.penalizacion = penalizacion;
        }

        public void RegistrarEnvio(int tiempo, int equipo, int problema, bool correcto)
        {
            equipos[equipo - 1].MandarSolucion(tiempo, problema, correcto);
        }

        public void RegistrarDescalificacion(int tiempo, int equipo)
        {
            equipos[equipo - 1].Descalificar(tiempo);
        }

        public IEnumerable<int> TablaDePosiciones(int tiempo)
        {
            List<Equipo> sinDesc = new List<Equipo>();
            for (int i = 0; i < equipos.Count; i++)
            {
                Equipo e = equipos[i];
                if (e.Descalificado == null || e.Descalificado > tiempo)
                    sinDesc.Add(e);
            }
            //sinDesc.Sort((x, y) => y.CantResueltos() - x.CantResueltos());
            //return from n in sinDesc select n.Number;
            //return from n in sinDesc select n.Number;
            return from n in sinDesc orderby n.CantResueltos(tiempo) descending, n.GetPenalty(tiempo) select n.Number;
        }

        public IEnumerable<int> EquiposDescalificados(int tiempo)
        {
            return from e in equipos where (e.Descalificado != null && e.Descalificado < tiempo) select e.Number;
        }

        public IEnumerable<int> ProblemasResueltos(int tiempo, int equipo)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < m; i++)
            {
                if (equipos[equipo - 1].resueltos[i] && equipos[equipo - 1].envios[i][equipos[equipo - 1].envios[i].Count - 1] <= tiempo)
                    list.Add(i + 1);
            }
            return list;
        }

        public IEnumerable<int> ProblemasConMasSoluciones(int tiempo)
        {
            int[] cont = new int[m];
            foreach (var item in equipos)
            {
                for (int i = 0; i < m; i++)
                {
                    if (item.resueltos[i] && item.envios[i][item.envios[i].Count - 1] <= tiempo)
                        cont[i]++;
                }
            }
            Tuple<int, int>[] lol = new Tuple<int, int>[m];
            for (int i = 0; i < lol.Length; i++)
            {
                lol[i] = new Tuple<int, int>(i + 1, cont[i]);
            }
            return from n in lol orderby n.Item2 descending select n.Item1;
        }

        public int Penalizacion { get; }
    }
}