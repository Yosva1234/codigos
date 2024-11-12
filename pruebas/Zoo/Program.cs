using System.Diagnostics;
using zoologico;

class Program
{
    static void Main()
    {
        // Esto está aquí para que no te olvides de implementarlo
        Console.WriteLine($"{MatCom.Exam.Exam.Nombre} - {MatCom.Exam.Exam.Grupo}");

        // Creando un registro
        var rc = MatCom.Exam.Exam.CreateRecord();

        // Creando dos áreas en el Zoológico
        var root = rc.GetArea("Zoologico");
        var prad = root.CreateArea("PraderaAfricana");
        var rept = root.CreateArea("Reptiles");

        // Agregando 10 animales dentro de la pradera africana
        for (int i = 0; i < 10; i++)
            prad.CreateAnimal($"Leon{i}", 5, "León");

        // Verificando la edad media en la pradera africana
        Debug.Assert(prad.MeanAge() == 5);

        // Agregando animales al área de los reptiles
        rept.CreateAnimal("Cascabel", 8, "Serpiente");
        rept.CreateAnimal("Python", 14, "Serpiente");
        rept.CreateAnimal("Anaconda", 6, "Serpiente");

        // Buscando un animal concreto
        var pyt = rc.GetAnimal("Zoologico/Reptiles/Python");
        Debug.Assert(pyt.Name == "Python");

        // Verificando el método `Find` con los leones
        foreach (var animal in rc.Find(animal => animal.Specie == "León"))
            Debug.Assert(animal.Specie == "León");

        // Verificando el método `Find` con edad
        foreach (var animal in rc.Find(animal => animal.Age > 12))
            Debug.Assert(animal.Age > 12);

        // Ahora vamos a mover los reptiles para la pradera africana
        rc.Move("Zoologico/Reptiles", "Zoologico/PraderaAfricana");
        Debug.Assert(prad.MeanAge() == 6);
        Debug.Assert(rc.GetArea("Zoologico/PraderaAfricana/Reptiles").Name ==
                "Reptiles");

        // Añade tus pruebas aquí
        // ...
    }
}
