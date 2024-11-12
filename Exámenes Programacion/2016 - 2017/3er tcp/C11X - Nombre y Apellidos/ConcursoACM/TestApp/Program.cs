using System;
using System.Linq;
using Weboo.Examen;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            //Se crea un nuevo concurso con 8 participantes, 5 problemas y una penalización de 20 min
            Concurso copaUH = new Concurso(8, 5, 20);

            //El equipo 1 hace un envío incorrecto al problema 5 en el minuto 3
            copaUH.RegistrarEnvio(3, 1, 5, false);

            //El equipo 2 hace un envío correcto al problema 5 en el minuto 4
            copaUH.RegistrarEnvio(4, 2, 5, true);

            //El equipo 1 hace un envío correcto al problema 5 en el minuto 5
            copaUH.RegistrarEnvio(5, 1, 5, true);

            //El equipo 3 hace un envío correcto al problema 5 en el minuto 6
            copaUH.RegistrarEnvio(6, 3, 5, true);

            //El equipo 4 hace un envío correcto al problema 5 en el minuto 6
            copaUH.RegistrarEnvio(6, 4, 5, true);

            //El equipo 5 hace un envío correcto al problema 5 en el minuto 10
            copaUH.RegistrarEnvio(10, 5, 5, true);

            //El equipo 2 hace un envío incorrecto al problema 3 en el minuto 15
            copaUH.RegistrarEnvio(15, 2, 3, false);

            //El equipo 2 hace un envío correcto al problema 3 en el minuto 17
            copaUH.RegistrarEnvio(17, 2, 3, true);

            //El equipo 5 hace un envío correcto al problema 3 en el minuto 20
            copaUH.RegistrarEnvio(20, 5, 3, true);


            //Consultas a la tabla de posiciones en los minutos 2, 7 y 30
            int[] tablaMin2 = copaUH.TablaDePosiciones(2).ToArray(); //{1, 2, 3, 4, 5, 6, 7, 8} <- No importa el orden, solo tienen que estar todos!
            PrettyPrint(tablaMin2, "Posiciones en el minuto 2. Todos estan en posición 0");

            int[] tablaMin7 = copaUH.TablaDePosiciones(7).ToArray(); //{2, 3, 4, 1, 7, 8, 5, 6}
            PrettyPrint(tablaMin7, "Posiciones en el minuto 7");

            int[] tablaMin30 = copaUH.TablaDePosiciones(30).ToArray(); //{5, 2, 4, 3, 1, 8, 7, 6}
            PrettyPrint(tablaMin30, "Posiciones en el minuto 30");


            //No hay equipos descalificados hasta el momento
            int[] descMin30 = copaUH.EquiposDescalificados(30).ToArray(); //{ }
            PrettyPrint(descMin30, "Descalificaciones hasta el minuto 30");


            //Son descalificados los equipos 4 y 7 en los minutos 33 y 40 respectivamente
            copaUH.RegistrarDescalificacion(33, 4);
            copaUH.RegistrarDescalificacion(40, 7);


            //Notar el cambio antes y después de decalificar al equipo 4
            int[] tablaMin32 = copaUH.TablaDePosiciones(32).ToArray(); //{5, 2, 4, 3, 1, 8, 7, 6}
            PrettyPrint(tablaMin32, "Posiciones en el minuto 32");

            int[] tablaMin34 = copaUH.TablaDePosiciones(34).ToArray(); //{5, 2, 3, 1, 8, 7, 6}
            PrettyPrint(tablaMin34, "Posiciones en el minuto 34. Equipo 4 descalificado");

            //... y después de descalificar al equipo 7
            int[] tablaMin41 = copaUH.TablaDePosiciones(41).ToArray(); //{5, 2, 3, 1, 8, 6}
            PrettyPrint(tablaMin41, "Posiciones en el minuto 34. Equipo 7 descalificado");

            //Equipos descalificados en los minutos 34 y 41
            int[] descMin34 = copaUH.EquiposDescalificados(34).ToArray(); //{4}
            PrettyPrint(descMin34, "Descalificados hasta el minuto 34");

            int[] descMin41 = copaUH.EquiposDescalificados(41).ToArray(); //{4, 7}
            PrettyPrint(descMin41, "Descalificados hasta el minuto 41");

            //Problemas resueltos por los equipos 1, 5 y 8 hasta el minuto 16
            int[] probEq1Min16 = copaUH.ProblemasResueltos(16, 1).ToArray(); //{5}
            PrettyPrint(probEq1Min16, "Problemas resuletos por el equipo 1 hasta el minuto 16");

            int[] probEq5Min16 = copaUH.ProblemasResueltos(16, 5).ToArray(); //{5}
            PrettyPrint(probEq5Min16, "Problemas resuletos por el equipo 5 hasta el minuto 16");

            int[] probEq8Min16 = copaUH.ProblemasResueltos(16, 8).ToArray(); //{}
            PrettyPrint(probEq8Min16, "Problemas resuletos por el equipo 8 hasta el minuto 16");

            //Problemas resueltos por los equipos 1, 5 y 8 hasta el minuto 45
            int[] probEq1Min45 = copaUH.ProblemasResueltos(45, 1).ToArray(); //{5}
            PrettyPrint(probEq1Min45, "Problemas resuletos por el equipo 1 hasta el minuto 45");

            int[] probEq5Min45 = copaUH.ProblemasResueltos(45, 5).ToArray(); //{3, 5}
            PrettyPrint(probEq5Min45, "Problemas resuletos por el equipo 5 hasta el minuto 45");

            int[] probEq8Min45 = copaUH.ProblemasResueltos(45, 8).ToArray(); //{}
            PrettyPrint(probEq8Min45, "Problemas resuletos por el equipo 8 hasta el minuto 45");

            //Problemas con más soluciones en los minutos 0, 7 y 18
            int[] probSolMin0 = copaUH.ProblemasConMasSoluciones(0).ToArray(); //{1, 2, 3, 4, 5}
            PrettyPrint(probSolMin0, "Problemas más resuletos hasta el minuto 0");

            int[] probSolMin7 = copaUH.ProblemasConMasSoluciones(7).ToArray(); //{5, 1, 2, 3, 4}
            PrettyPrint(probSolMin7, "Problemas más resuletos hasta el minuto 7");

            int[] probSolMin18 = copaUH.ProblemasConMasSoluciones(18).ToArray(); //{5, 3, 1, 2, 4}
            PrettyPrint(probSolMin18, "Problemas más resuletos hasta el minuto 18");
            
            Console.ReadLine();
        }

        #region Utils

        private static void PrettyPrint<T>(T[] arr, string title = "", char separator = ' ')
        {
            Console.WriteLine();

            if (!string.IsNullOrEmpty(title))
                Console.WriteLine(title);

            Console.Write("{0}{1}", "{", separator);
            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 0) Console.Write(",{0}", separator);
                Console.Write(arr[i]);
            }
            Console.WriteLine("{0}{1}", separator, "}");

            Console.WriteLine();
        }
        #endregion
    }
}