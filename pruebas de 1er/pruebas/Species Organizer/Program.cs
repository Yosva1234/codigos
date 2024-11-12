using System;
using System.Diagnostics;

namespace MatCom.Exam
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Exam.Nombre);
            Console.WriteLine(Exam.Grupo);

            ExampleCase();
        }

        static void ExampleCase()
        {
            ISpeciesOrganizer organizer = Exam.GetSpeciesOrganizer();

            // Referencia al grupo taxonómico raíz
            ITaxonomicGroup root = organizer.Root;

            // Crear los grupos taxonómicos iniciales
            ITaxonomicGroup felidae = root.CreateSubtaxonomicGroup("Felidae");
            ITaxonomicGroup canidae = root.CreateSubtaxonomicGroup("Canidae");

            // Crear los subgrupos taxonómicos
            ITaxonomicGroup felis = felidae.CreateSubtaxonomicGroup("Felis");
            ITaxonomicGroup panthera = felidae.CreateSubtaxonomicGroup("Panthera");
            ITaxonomicGroup canis = canidae.CreateSubtaxonomicGroup("Canis");
            ITaxonomicGroup cuon = canidae.CreateSubtaxonomicGroup("Cuon");

            // Crear las especies
            felis.UpdateSpecimen("Catus", 3);
            felis.UpdateSpecimen("Silvestris", 2);

            panthera.UpdateSpecimen("Leo", 4);
            panthera.UpdateSpecimen("Tigris", 1);
            panthera.UpdateSpecimen("Onca", 2);

            canis.UpdateSpecimen("Lupus familiaris", 1);
            canis.UpdateSpecimen("Lupus", 5);
            canis.UpdateSpecimen("Latrans", 2);

            cuon.UpdateSpecimen("Alpinus", 3);
            cuon.UpdateSpecimen("Alpinus lupaster", 1);

            // Hasta aquí tenemos los grupos taxonómicos y especies del ejemplo

            // Crear un nuevo grupo taxonómico
            ITaxonomicGroup acinonyx = felidae.CreateSubtaxonomicGroup("Acinonyx");
            Debug.Assert(acinonyx == organizer.GetTaxonomicGroup("Felidae", "Acinonyx"));

            // Disminuye en 1 la cantidad de gatos
            felis.UpdateSpecimen("Catus", -1);
            Debug.Assert(organizer.GetSpecies("Catus", "Felidae", "Felis").Count == 2);

            // Crea una nueva especie
            felis.UpdateSpecimen("Uncia", 10);
            Debug.Assert(organizer.GetSpecies("Uncia", "Felidae", "Felis").Count == 10);

            // Obtener todas las especies que tienen menos de 3
            foreach (var specie in organizer.FindAll(s => s.Count < 3))
            {
                // Verificando que efectivamente tiene menos de 3
                Debug.Assert(specie.Count > 0 && specie.Count < 3);
            }
        }
    }
}



